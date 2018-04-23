using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.API.Native;

namespace BookmarkInsertLR {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            richEditControl1.CreateNewDocument();
            richEditControl1.Options.Bookmarks.Visibility = DevExpress.XtraRichEdit.RichEditBookmarkVisibility.Visible;
            Document document = richEditControl1.Document;
            document.InsertText(document.CreatePosition(0), "Bookmark 1Bookmark 2Bookmark 3Bookmark 4");
            document.CreateBookmark(document.CreateRange(0, 10), "b1");
            document.CreateBookmark(document.CreateRange(10, 10), "b2");
            document.CreateBookmark(document.CreateRange(20, 10), "b3");
            document.CreateBookmark(document.CreateRange(30, 10), "b4");
            document.CreateBookmark(document.CreateRange(5, 15), "b5");
            cbBookmarks.Items.AddRange(new string[] { "b1", "b2", "b3", "b4", "b5" });

        }
        int count = 0;
        private void btnLeft_Click(object sender, EventArgs e) {
            count++;
            Document document = richEditControl1.Document;
            document.BeginUpdate();
            DocumentRange textRange = document.InsertText(document.CaretPosition, "L" + count.ToString());
            CorrectBookmarksStart(textRange.Start, textRange.End);
            CorrectBookmarksEnd(textRange.Start, textRange.End);
            document.EndUpdate();
        }

        private void btnRight_Click(object sender, EventArgs e) {
            count++;
            Document document = richEditControl1.Document;
            document.BeginUpdate();
            DocumentRange textRange = document.InsertText(document.CaretPosition, "R" + count.ToString());
            CorrectBookmarksStart(textRange.End, textRange.Start);
            CorrectBookmarksEnd(textRange.End, textRange.Start);
            document.EndUpdate();
            
        }

        private void btnBetween_Click(object sender, EventArgs e) {
            count++;
            Document document = richEditControl1.Document;
            document.BeginUpdate();
            DocumentRange textRange = document.InsertText(document.CaretPosition, "B" + count.ToString());
            CorrectBookmarksStart(textRange.Start, textRange.End);
            CorrectBookmarksEnd(textRange.End, textRange.Start);
            document.EndUpdate();
            
        }
        void CorrectBookmarksStart(DocumentPosition oldBookmarkStart, DocumentPosition newBookmarkStart) {
            Document document = richEditControl1.Document;
            document.BeginUpdate();
            List<Bookmark> bookmarksAtRight = new List<Bookmark>();
            foreach (Bookmark bookmark in document.Bookmarks) {
                if (bookmark.Range.Start.ToInt() == oldBookmarkStart.ToInt())
                    bookmarksAtRight.Add(bookmark);
            }
            foreach (Bookmark bookmark in bookmarksAtRight) {
                int bookmarkEnd = bookmark.Range.End.ToInt();
                string bookmarkName = bookmark.Name;
                document.RemoveBookmark(bookmark);
                document.CreateBookmark(newBookmarkStart, bookmarkEnd - newBookmarkStart.ToInt(), bookmarkName);
            }
            document.EndUpdate();
        }
        void CorrectBookmarksEnd(DocumentPosition oldBookmarkEnd, DocumentPosition newBookmarkEnd) {
            Document document = richEditControl1.Document;
            document.BeginUpdate();
            List<Bookmark> bookmarksAtLeft = new List<Bookmark>();
            foreach (Bookmark bookmark in document.Bookmarks) {
                if (bookmark.Range.End.ToInt() == oldBookmarkEnd.ToInt())
                    bookmarksAtLeft.Add(bookmark);
            }
            foreach (Bookmark bookmark in bookmarksAtLeft) {
                int bookmarkStart = bookmark.Range.Start.ToInt();
                string bookmarkName = bookmark.Name;
                document.RemoveBookmark(bookmark);
                document.CreateBookmark(document.CreatePosition(bookmarkStart), newBookmarkEnd.ToInt() - bookmarkStart, bookmarkName);
            }
            document.EndUpdate();
        }

        private void cbBookmarks_SelectedValueChanged(object sender, EventArgs e) {
            Document document = richEditControl1.Document;
            string value = cbBookmarks.SelectedItem as String;
            if(String.IsNullOrEmpty(value))
                return;
            document.SelectBookmark(document.Bookmarks[value]);
        }
    }
}
