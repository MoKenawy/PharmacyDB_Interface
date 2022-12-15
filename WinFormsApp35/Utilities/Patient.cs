using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp35.Tables
{
    internal class Patient
    {
        int ID;
        string name;
        string address;
        string[] phoneNumbers= new string[2];
        public Patient(int ID, string name, string address, params string[] phoneNumbers){
            this.ID = ID;
            this.name = name;
            this.address = address;
            this.phoneNumbers[0] = phoneNumbers[0];
            this.phoneNumbers[1] = phoneNumbers[1];
        }
        public Patient(string name, string address, string phoneNumbers) : this(0,name,address,phoneNumbers){
        
        }
    }
}
