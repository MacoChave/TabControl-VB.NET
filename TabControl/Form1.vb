Public Class Form1
    Dim contarTabPage As Integer = 0

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        Dim textPage As String = "Pestaña " & (contarTabPage + 1)
        Dim namePage As String = "Pestaña" & contarTabPage

        addPage(textPage, namePage, "Puedes comenzar aquí...")
    End Sub

    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        Dim OFD As New OpenFileDialog
        OFD.Title = "Seleccione un archivo"
        OFD.Filter = "Archivo TXT | *.txt"
        OFD.ShowDialog()

        Dim SR As New IO.StreamReader(OFD.FileName)
        Dim namePage As String = "Pestaña" & contarTabPage
        addPage(OFD.SafeFileName, namePage, SR.ReadToEnd)
    End Sub
    Private Sub addPage(textPage As String, namePage As String, texto As String)
        Dim newPage As New TabPage()
        newPage.Text = textPage
        newPage.Name = namePage
        TabControl.TabPages.Add(newPage)

        addRchText(newPage, contarTabPage, texto)
        contarTabPage += 1
        TabControl.SelectedTab = newPage
    End Sub

    Private Sub addRchText(newPage As TabPage, contarTabPage As Integer, texto As String)
        Dim newRchText As New RichTextBox
        newRchText.Name = "RichTextBox" & contarTabPage
        newRchText.Parent = newPage
        newRchText.Text = texto
        newRchText.Dock = DockStyle.Fill
        newRchText.ForeColor = Color.Purple
        newRchText.Visible = True

        newPage.Controls.Add(newRchText)
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        Try
            Dim childControl As Control
            If (TabControl.SelectedTab.HasChildren) Then
                For Each childControl In TabControl.SelectedTab.Controls
                    If TypeOf childControl Is RichTextBox Then
                        Try
                            Dim SFD As New SaveFileDialog
                            SFD.Title = "Selecciona el destino"
                            SFD.Filter = "Archivo txt | *.txt"
                            SFD.ShowDialog()

                            Dim sw As New IO.StreamWriter(SFD.FileName)
                            sw.Write(childControl.Text) 'COMPONENTE DEL QUE SE OBTENDRÁ EL TEXTO
                            sw.Close()
                        Catch ex As Exception
                            MessageBox.Show("¡No se pudo guardar el archivo!")
                        End Try
                    End If
                Next
            End If

        Catch ex As Exception
            MessageBox.Show("¡No hay pestañas abiertas!", "Error")
        End Try

    End Sub

    Private Sub CerrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarToolStripMenuItem.Click
        Try
            TabControl.TabPages.Remove(TabControl.SelectedTab)
        Catch ex As Exception
            MessageBox.Show("¡No hay pestañas abiertas!", "Error")
        End Try
    End Sub

    Private Sub CerrarTodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarTodoToolStripMenuItem.Click
        Try
            TabControl.TabPages.Clear()
        Catch ex As Exception
            MessageBox.Show("¡No hay pestañas abiertas!", "Error")
        End Try

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub



End Class
