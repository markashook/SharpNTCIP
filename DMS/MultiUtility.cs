using System;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// Utilities for working with Markup Language for Transportation 
    /// Information 
    /// </summary>
    public class MultiString
    {
        public MultiString(string multiString)
        {
            this.Multi = multiString;
        }

        private XDocument multiDocument;
        public XDocument MultiDocument
        {
            get { return multiDocument; }
            set { multiDocument = value; }
        }


        public string Multi
        {
            get
            {
                string retString;
                //Remove outer tag
                Regex outerStrip = new Regex("</?multi>");
                retString = outerStrip.Replace(multiDocument.ToString(), string.Empty);
                
                //Replace all square brackets with double square brackets
                retString = retString.Replace("[", "[[").Replace("]", "]]");

                //Replace all angle brackets with single square brackets
                retString = retString.Replace("<", "[").Replace(" />", "]");

                //Replace XML formatted characters with ASCII
                retString = retString
                    .Replace("&quot;", "\"")
                    .Replace("&apos;", "'")
                    .Replace("&gt;", ">")
                    .Replace("&lt;", "<")
                    .Replace("&amp;", "&");
    
                return retString;
            }
            set
            {
                //Replace illegal XML characters with acceptable ones (ampersand must be first)
                string tempString = value
                    .Replace("&", "&amp;")
                    .Replace("<", "&lt;")
                    .Replace(">", "&gt;")
                    .Replace("'", "&apos;")
                    .Replace("\"", "&quot;");

                //Replace all square brackets appearing alone (single) with xml tag ends "<" and ">"
                Regex openRegex = new Regex(@"(?<!\[)\[(?!\[)", RegexOptions.Compiled);
                Regex closeRegex = new Regex(@"(?<!\])\](?!\])", RegexOptions.Compiled);
                tempString = closeRegex.Replace(openRegex.Replace(tempString, "<"), " />");

                //Replace all double square brackets with single square brackets
                tempString = tempString.Replace("[[", "[").Replace("]]", "]");
                multiDocument = XDocument.Parse("<multi>" + tempString + "</multi>");

            }
        }

        public override string ToString()
        {
            Regex bracketStrip = new Regex(@"\[\w+\]");
            return bracketStrip.Replace(this.Multi, string.Empty);
        }

    }
}
