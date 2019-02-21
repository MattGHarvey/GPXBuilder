Public Class frmAbout
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub lnkGitHub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGitHub.LinkClicked
        Process.Start("https://github.com/MattGHarvey/GPXBuilder")
    End Sub
End Class