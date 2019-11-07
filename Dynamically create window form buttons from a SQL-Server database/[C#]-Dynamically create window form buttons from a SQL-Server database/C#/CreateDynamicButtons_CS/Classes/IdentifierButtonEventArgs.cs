using System;

namespace CreateDynamicTextBoxes_CS
{
    public class IdentifierButtonEventArgs : EventArgs
    {
        public IdentifierButtonEventArgs(int id)
        {
            Identifier = id;
        }

        public int Identifier { get; set; }
    }
}
