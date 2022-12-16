using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp35.Utilities
{
    public class TextBoxValidator
    {
        public List<TextBox> CompletenessValidator { get; set; }
        public List<TextBox> FormatValidator { get; set; }
        public List<TextBox> RangeValidator { get; set; }
        public List<TextBox> ConsistencyValidator { get; set; }
        public List<TextBox> CheckDigitValidator { get; set; }
        List<TextBox> result;


        public List<TextBox> IsComplete() {
            result = new List<TextBox>();
            foreach (TextBox textBox in CompletenessValidator) {
                string s  = textBox.Text;
                if (s != null || s != "")
                    result.Add(textBox);
            }
            return result;
        }
        public List<TextBox> InFormat(List<StringFormat> formats) {
        return result;
        }
        public List<TextBox> InRange() {
            return result;
        }
        public List<TextBox> IsConsistent() {
            return result;
        }
        public List<TextBox> DigitChecked() {
            return result;
        }



    }
}
