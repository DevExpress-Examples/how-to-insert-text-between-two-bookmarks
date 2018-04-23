Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit.API.Native

Namespace BookmarkInsertLR
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            richEditControl1.CreateNewDocument()
            richEditControl1.Options.Bookmarks.Visibility = DevExpress.XtraRichEdit.RichEditBookmarkVisibility.Visible
            Dim document As Document = richEditControl1.Document
            document.InsertText(document.CreatePosition(0), "Bookmark 1Bookmark 2Bookmark 3Bookmark 4")
            document.Bookmarks.Create(document.CreateRange(0, 10), "b1")
            document.Bookmarks.Create(document.CreateRange(10, 10), "b2")
            document.Bookmarks.Create(document.CreateRange(20, 10), "b3")
            document.Bookmarks.Create(document.CreateRange(30, 10), "b4")
            document.Bookmarks.Create(document.CreateRange(5, 15), "b5")
            cbBookmarks.Items.AddRange(New String() { "b1", "b2", "b3", "b4", "b5" })

        End Sub
        Private count As Integer = 0
        Private Sub btnLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLeft.Click
            count += 1
            Dim document As Document = richEditControl1.Document
            document.BeginUpdate()
            Dim textRange As DocumentRange = document.InsertText(document.CaretPosition, "L" & count.ToString())
            CorrectBookmarksStart(textRange.Start, textRange.End)
            CorrectBookmarksEnd(textRange.Start, textRange.End)
            document.EndUpdate()
        End Sub

        Private Sub btnRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRight.Click
            count += 1
            Dim document As Document = richEditControl1.Document
            document.BeginUpdate()
            Dim textRange As DocumentRange = document.InsertText(document.CaretPosition, "R" & count.ToString())
            CorrectBookmarksStart(textRange.End, textRange.Start)
            CorrectBookmarksEnd(textRange.End, textRange.Start)
            document.EndUpdate()

        End Sub

        Private Sub btnBetween_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBetween.Click
            count += 1
            Dim document As Document = richEditControl1.Document
            document.BeginUpdate()
            Dim textRange As DocumentRange = document.InsertText(document.CaretPosition, "B" & count.ToString())
            CorrectBookmarksStart(textRange.Start, textRange.End)
            CorrectBookmarksEnd(textRange.End, textRange.Start)
            document.EndUpdate()

        End Sub
        Private Sub CorrectBookmarksStart(ByVal oldBookmarkStart As DocumentPosition, ByVal newBookmarkStart As DocumentPosition)
            Dim document As Document = richEditControl1.Document
            document.BeginUpdate()
            Dim bookmarksAtRight As New List(Of Bookmark)()
            For Each bookmark As Bookmark In document.Bookmarks
                If bookmark.Range.Start.ToInt() = oldBookmarkStart.ToInt() Then
                    bookmarksAtRight.Add(bookmark)
                End If
            Next bookmark
            For Each bookmark As Bookmark In bookmarksAtRight
                Dim bookmarkEnd As Integer = bookmark.Range.End.ToInt()
                Dim bookmarkName As String = bookmark.Name
                document.Bookmarks.Remove(bookmark)
                document.Bookmarks.Create(newBookmarkStart, bookmarkEnd - newBookmarkStart.ToInt(), bookmarkName)
            Next bookmark
            document.EndUpdate()
        End Sub
        Private Sub CorrectBookmarksEnd(ByVal oldBookmarkEnd As DocumentPosition, ByVal newBookmarkEnd As DocumentPosition)
            Dim document As Document = richEditControl1.Document
            document.BeginUpdate()
            Dim bookmarksAtLeft As New List(Of Bookmark)()
            For Each bookmark As Bookmark In document.Bookmarks
                If bookmark.Range.End.ToInt() = oldBookmarkEnd.ToInt() Then
                    bookmarksAtLeft.Add(bookmark)
                End If
            Next bookmark
            For Each bookmark As Bookmark In bookmarksAtLeft
                Dim bookmarkStart As Integer = bookmark.Range.Start.ToInt()
                Dim bookmarkName As String = bookmark.Name
                document.Bookmarks.Remove(bookmark)
                document.Bookmarks.Create(document.CreatePosition(bookmarkStart), newBookmarkEnd.ToInt() - bookmarkStart, bookmarkName)
            Next bookmark
            document.EndUpdate()
        End Sub

        Private Sub cbBookmarks_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbBookmarks.SelectedValueChanged
            Dim document As Document = richEditControl1.Document
            Dim value As String = TryCast(cbBookmarks.SelectedItem, String)
            If String.IsNullOrEmpty(value) Then
                Return
            End If
            document.Bookmarks.Select(document.Bookmarks(value))
        End Sub
    End Class
End Namespace
