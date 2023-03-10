using DevExpress.CodeParser;
using DevExpress.DataAccess.UI.Native.Sql;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextEdit
{
    /// <summary>
    /// Define an parser
    /// </summary>
    public class csXMLSyntaxHighLightService : ISyntaxHighlightService
    {

        readonly Document document;
        SyntaxHighlightProperties highlightDefault = new SyntaxHighlightProperties() { ForeColor = Color.Brown };
        SyntaxHighlightProperties highLightKeyword1 = new SyntaxHighlightProperties() { ForeColor = Color.Blue };
        SyntaxHighlightProperties highlightKeyword2 = new SyntaxHighlightProperties() { ForeColor = Color.Red };
        SyntaxHighlightProperties highlightString = new SyntaxHighlightProperties() { ForeColor = Color.Black };

        string[] keywords1 = new string[] {
            "version", "encoding", "application", "value", "=", "</", "/>", "<", ">"};

        string[] keywords2 = new string[] {
            "name", "attribute" };

        public csXMLSyntaxHighLightService(Document document)
        {
            this.document = document;
        }

        private List<SyntaxHighlightToken> ParseTokens()
        {
            List<SyntaxHighlightToken> tokens = new List<SyntaxHighlightToken>();

            try
            {
                DocumentRange[] ranges = null;
                // search for quotation marks
                ranges = document.FindAll("\"", SearchOptions.None);
                for (int i = 0; i < ranges.Length / 2; i++)
                {
                    tokens.Add(new SyntaxHighlightToken(ranges[i * 2].Start.ToInt(),
                        ranges[i * 2 + 1].Start.ToInt() - ranges[i * 2].Start.ToInt() + 1, highlightString));
                }
                // search for keywords
                for (int i = 0; i < keywords1.Length; i++)
                {
                    ranges = document.FindAll(keywords1[i], SearchOptions.None);

                    for (int j = 0; j < ranges.Length; j++)
                    {
                        if (!IsRangeInTokens(ranges[j], tokens))
                            tokens.Add(new SyntaxHighlightToken(ranges[j].Start.ToInt(), ranges[j].Length, highLightKeyword1));
                    }
                }

                // search for keywords1
                for (int i = 0; i < keywords2.Length; i++)
                {
                    ranges = document.FindAll(keywords2[i], SearchOptions.None);

                    for (int j = 0; j < ranges.Length; j++)
                    {
                        if (!IsRangeInTokens(ranges[j], tokens))
                            tokens.Add(new SyntaxHighlightToken(ranges[j].Start.ToInt(), ranges[j].Length, highlightKeyword2));
                    }
                }

                // order tokens by their start position
                tokens.Sort(new SyntaxHighlightTokenComparer());
                // fill in gaps in document coverage
                AddPlainTextTokens(tokens);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csXMLSyntaxHighLightService.ParseTokens:\r\n" + ex.Message);
            }


            return tokens;
        }

        private void AddPlainTextTokens(List<SyntaxHighlightToken> tokens)
        {
            int count = tokens.Count;
            if (count == 0)
            {
                tokens.Add(new SyntaxHighlightToken(0, document.Range.End.ToInt(), highlightDefault));
                return;
            }
            tokens.Insert(0, new SyntaxHighlightToken(0, tokens[0].Start, highlightDefault));
            for (int i = 1; i < count; i++)
            {
                tokens.Insert(i * 2, new SyntaxHighlightToken(tokens[i * 2 - 1].End, tokens[i * 2].Start - tokens[i * 2 - 1].End, highlightDefault));
            }
            tokens.Add(new SyntaxHighlightToken(tokens[count * 2 - 1].End, document.Range.End.ToInt() - tokens[count * 2 - 1].End, highlightDefault));
        }

        private bool IsRangeInTokens(DocumentRange range, List<SyntaxHighlightToken> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                if (range.Start.ToInt() >= tokens[i].Start && range.End.ToInt() <= tokens[i].End)
                    return true;
            }
            return false;
        }

        public void ForceExecute()
        {
            Execute();
        }
        public void Execute()
        {
            try
            {
                document.ApplySyntaxHighlight(ParseTokens());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csXMLSyntaxHighLightService.Execute:\r\n" + ex.Message);
            }
        }
    }

    public class SyntaxHighlightTokenComparer : IComparer<SyntaxHighlightToken>
    {
        public int Compare(SyntaxHighlightToken x, SyntaxHighlightToken y)
        {
            return x.Start - y.Start;
        }
    }


}
