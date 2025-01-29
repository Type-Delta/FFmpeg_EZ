using FFmpeg_EZ.subform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFmpeg_EZ
{
    public static class AppControl
    {



        public static bool isInBoundOf(this Point mousePos, dynamic control)
        {
            /*Point mouse = new Point(
                mousePos.X - control.Parent.Location.X - control.Location.X,
                mousePos.Y - control.Parent.Location.Y - control.Location.Y
            );*/
            Point mouse = inScopeOf(mousePos, control); //similar to ^
            
            if (control.ClientRectangle.Contains(mouse)) return true;
            return false;
        }

        public static bool isInBoundOf(this Point mousePos, dynamic control, Rectangle controlRec)
        {
            //Point mouse = inScopeOf(mousePos, control, 0);
            controlRec = new Rectangle(
                absolutePos(control).X + controlRec.X,
                absolutePos(control).Y + controlRec.Y,
                controlRec.Width,
                controlRec.Height);
            if (controlRec.Contains(mousePos)) return true;
            return false;
        }

        /// <summary>
        /// get Location in the same scope as the given Control
        /// Note: Location needs to be relative to the Form (in the scope of Form)
        /// otherwise will give the wrong result
        /// </summary>
        /// <param name="globleLocation">the Location in the scope of Form</param>
        /// <param name="control"></param>
        /// <returns>local Location in the same scope as Control</returns>
        public static Point inScopeOf(this Point globleLocation, dynamic control, int skip = 0)
        {
            int localX = globleLocation.X;
            int localY = globleLocation.Y;
            for(
                dynamic _control = control;
                _control != null&&_control.Parent != null; // filter the Form out
                _control = _control.Parent
            )
            {
                if(skip > 0)
                {
                    skip--;
                    continue;
                }
                localX -= _control.Location.X;
                localY -= _control.Location.Y;
            }

            return new Point(localX, localY);
        }

        public static Point absolutePos<T>(this T control)
        {
            int localX = 0;
            int localY = 0;
            for (
                dynamic _control = control;
                _control != null && _control.Parent != null; // filter the Form out
                _control = _control.Parent
            )
            {
                localX += _control.Location.X;
                localY += _control.Location.Y;
            }

            return new Point(localX, localY);
        }

        public static Rectangle absoluteRec<T>(this T control, Rectangle rec)
        {
            Point pos = control.absolutePos();
            return new Rectangle(
                pos.X + rec.X,
                pos.Y + rec.Y,
                rec.Width,
                rec.Height
            );
        }

        public static bool HasMethod<T>(this T objectToCheck, string methodName)
        {
            var type = objectToCheck.GetType();
            return type.GetMethod(methodName) != null;
        }



        



        public static Rectangle GetItemAbsoluteRectangle(this ListBox lb, int index)
        {
            if(index < -1) throw new ArgumentOutOfRangeException("index: cannot be lessthan -1");
            Rectangle localRec;
            if (index == -1) localRec = lb.GetItemRectangle(lb.Items.Count - 1);
            else localRec = lb.GetItemRectangle(index);

            return new Rectangle(
                localRec.X + lb.Location.X,
                localRec.Y + lb.Location.Y,
                localRec.Width,
                localRec.Height
            );
        }


        /// <summary>
        /// resize control with an ability to defind anchorPoint in which control would be pined while resizing
        /// </summary>
        /// <param name="control"></param>
        /// <param name="newSize"></param>
        /// <param name="anchorPoint">control's corner to pin Ex: `tr` (top-right), `bl` (bottom-left), `br` (bottom-right)</param>
        public static void FixPointResize(dynamic control, Size newSize, string anchorPoint)
        {
            //Point startPos = control.Location;
            Size startSize = control.Size;
            int changedV = newSize.Height - startSize.Height;
            int changedH = newSize.Width - startSize.Width;

            switch (anchorPoint)
            {
                case "tl": break;
                case "tr":
                    control.Location = new Point(
                        control.Location.X + (changedH * -1),
                        control.Location.Y
                    );
                    break;

                case "bl":
                    control.Location = new Point(
                        control.Location.X,
                        control.Location.Y + (changedV * -1)
                    );
                    break;

                case "br":
                    control.Location = new Point(
                        control.Location.X + (changedH * -1),
                        control.Location.Y + (changedV * -1)
                    );
                    break;

                default: throw new ArgumentOutOfRangeException($"\"{anchorPoint}\" is not a valid anchorPoint");
            }
            
            control.Size = newSize;
        }






        ///   Events   ///
        public class DragNDropEventArgs
        {
            public DragNDropEventArgs(Point mousePos, dynamic itemDat) {
                MousePos = mousePos;
                DragItemData = itemDat;
            }
            public Point MousePos { get; } // readonly
            public dynamic DragItemData { get; }
        }

        public class DragNDrop
        {
            // Declare the delegate (if using non-generic pattern).
            public delegate void DragNDropEventHandler(object sender, DragNDropEventArgs e);

            // Declare the event.
            public event DragNDropEventHandler OnDropEvent;


            private static bool pickedUp = false;
            private static dynamic savedItemDat; //the data first save when Item being pickup
            private const float effectIconXMultOffset = 0.12F;
            private const float effectIconYMultOffset = 0.72F;
            // handles Drag&Drop and return Drop Location 
            public Point HandleDragNDrop(
                Rectangle dragStartRec, 
                Point mousePos, 
                PictureBox dragEffectIcon,
                dynamic itemData
            )
            {
                if (Control.MouseButtons == MouseButtons.Left)
                {
                    if (dragStartRec.Contains(mousePos) && !pickedUp)
                    { // when just pickedup
                        pickedUp = true;
                        savedItemDat = itemData;
                    }

                    if (pickedUp)
                    { // when holding
                        if(!dragEffectIcon.Visible) dragEffectIcon.Visible = true;
                        dragEffectIcon.Location = new Point(
                            mousePos.X - (int)(dragEffectIcon.Size.Width * effectIconXMultOffset),
                            mousePos.Y - (int)(dragEffectIcon.Size.Height * effectIconYMultOffset)
                        );
                    }

                }
                else if (pickedUp)
                { // when release
                    dragEffectIcon.Visible = false;
                    pickedUp = false;
                    InvokeDropEvent(mousePos, savedItemDat);
                    return mousePos;
                }
                return Point.Empty;
            }


            public Point HandleDragNDrop(
                Rectangle dragStartRec,
                Point mousePos,
                PictureBox dragEffectIcon,
                PictureBox dragEffectIcon_dropReady,
                dynamic itemData,
                Rectangle dropTarget              
            )
            {
                if (Control.MouseButtons == MouseButtons.Left)
                {
                    if (dragStartRec.Contains(mousePos) && !pickedUp)
                    { // when just pickedup
                        pickedUp = true;
                        savedItemDat = itemData;
                    }

                    if (pickedUp)
                    { // when holding
                        if (dropTarget.Contains(mousePos))
                        {
                            if (dragEffectIcon.Visible) dragEffectIcon.Visible = false;
                            if (!dragEffectIcon_dropReady.Visible) dragEffectIcon_dropReady.Visible = true;
                            dragEffectIcon_dropReady.Location = new Point(
                                mousePos.X - (int)(dragEffectIcon_dropReady.Size.Width * effectIconXMultOffset),
                                mousePos.Y - (int)(dragEffectIcon_dropReady.Size.Height * effectIconYMultOffset)
                            );
                        }
                        else
                        {
                            if (dragEffectIcon_dropReady.Visible) dragEffectIcon_dropReady.Visible = false;
                            if (!dragEffectIcon.Visible) dragEffectIcon.Visible = true;
                            dragEffectIcon.Location = new Point(
                                mousePos.X - (int)(dragEffectIcon.Size.Width * effectIconXMultOffset),
                                mousePos.Y - (int)(dragEffectIcon.Size.Height * effectIconYMultOffset)
                            );
                        }

                    }

                }
                else if (pickedUp)
                { // when release
                    dragEffectIcon.Visible = false;
                    dragEffectIcon_dropReady.Visible = false;
                    pickedUp = false;
                    InvokeDropEvent(mousePos, savedItemDat);
                    return mousePos;
                }
                return Point.Empty;
            }



          




            // Wrap the event in a protected virtual method
            // to enable derived classes to raise the event.
            protected virtual void InvokeDropEvent(Point p, dynamic dat)
            {
                // Raise the event in a thread-safe manner using the ?. operator.
                OnDropEvent?.Invoke(this, new DragNDropEventArgs(p, dat));
            }
        }
    }
}
