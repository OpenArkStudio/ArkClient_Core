using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFCoreEx
{
    public class AFIDENTID : Object
    {
        public Int32 nHead32;
        public Int32 nData32;

        public AFIDENTID()
        {
            nHead32 = 0;
            nData32 = 0;
        }

        public AFIDENTID(AFIDENTID id)
        {
            nHead32 = id.nHead32;
            nData32 = id.nData32;
        }

        public AFIDENTID(Int32 nHead, Int32 nData)
        {
            nHead32 = nHead;
            nData32 = nData;
        }

		public static bool operator == (AFIDENTID ident, AFIDENTID other)
		{
            if (((object)ident == null) && ((object)other == null))
            {
                return true;
            }

            if (((object)ident == null) || ((object)other == null))
            {
                return false;
            }

            return ident.nHead32 == other.nHead32 && ident.nData32 == other.nData32;
		}

		public static bool operator != (AFIDENTID ident, AFIDENTID other)
		{
            return !(ident == other);
		}

        public override bool Equals(object other)
        {
            return this == (AFIDENTID)other;
        }

        public bool IsNull()
        {
            return 0 == nData32 && 0 == nHead32;
        }

        public override string ToString()
        {
            return nHead32.ToString() + "-" + nData32.ToString();
        }

        public bool Parse(string strData, out AFIDENTID id)
        {
            AFIDENTID xId = new AFIDENTID();
            id = xId;

            string[] strList = strData.Split('-');
            if (strList.Count() != 2)
            {
                return false;
            }

            Int32 nHead = 0;
            if (!Int32.TryParse(strList[0], out nHead))
            {
                return false;
            }

            Int32 nData = 0;
            if (!Int32.TryParse(strList[1], out nData))
            {
                return false;
            }

            id.nHead32 = nHead;
            id.nData32 = nData;

            return true;
        }

        public override int GetHashCode()
        {
            string str =this.ToString();
            return str.GetHashCode();
        }
    }
}