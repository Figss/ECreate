Imports Microsoft.Data.SqlClient
Public Class formMenu
    Dim connectionString As String = "Server=commngtcc105.mssql.somee.com;Database=commngtcc105;
                                     
User Id=ublipa_SQLLogin_1;Password=nktg6ikffl;TrustServerCertificate=True;"

    Private Sub formMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = Image.FromFile("bottomLeft.png")
        PictureBox2.Image = Image.FromFile("bottomRight.png")
        PictureBox3.Image = Image.FromFile("topLeft.png")
        PictureBox4.Image = Image.FromFile("topRight.png")
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        LoadData()
    End Sub

    Private Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click
        'user info'
        Dim name = nameInfo.Text
        Dim contact = conInfo.Text
        Dim email = emailInfo.Text
        'event info'
        Dim eventN As String = eventName.Text
        Dim attendee = attendeeCo.Text
        Dim eventType = cmbType.SelectedItem.ToString
        Dim venue = cmbvenue.SelectedItem.ToString
        'schedule'
        Dim dateSche = dtpDate.Value
        Dim startT = TimeOnly.FromDateTime(DateTimePicker1.Value)
        Dim endT = TimeOnly.FromDateTime(DateTimePicker2.Value)

        Dim query = "INSERT INTO g6_userInfo (name, contact, email)" & "VALUES (@name, @contact, @email)"
        Dim query1 = "INSERT INTO g6_venueInfo (eventN, attendee, eventType, venue) 
                               VALUES (@eventN, @attendee, @eventType, @venue)"
        Dim query2 = "INSERT INTO g6_schedule (dateSche, startT, endT)  VALUES (@dateSche, @startT, @endT)"
        Dim query3 = "INSERT INTO g6_BookedVenue (EventName, Venue, DateBooked, StartTime, EndTime)  
                               VALUES (@EventName, @Venue, @DateBooked, @StartTime, @EndTime)"
        Dim query4 = "INSERT INTO g6_History (Name, Contact, Email, EventName, Venue, Attendees, Type, DateBooked, StartTime, EndTime)  
                               VALUES (@name, @contact, @Email, @EventName, @Venue, @Attendees, @Type, @DateBooked, @StartTime, @EndTime)"


        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@contact", contact)
                cmd.Parameters.AddWithValue("@email", email)

                Try
                    conn.Open()
                    ' Execute the query
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    ' Handle any exceptions
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using

        Using conn As New SqlConnection(connectionString)
            Using cmd2 As New SqlCommand(query1, conn)
                cmd2.Parameters.AddWithValue("@eventN", eventN)
                cmd2.Parameters.AddWithValue("@attendee", attendee)
                cmd2.Parameters.AddWithValue("@eventType", eventType)
                cmd2.Parameters.AddWithValue("@venue", venue)

                Try
                    conn.Open()
                    ' Execute the query
                    cmd2.ExecuteNonQuery()
                Catch ex As Exception
                    ' Handle any exceptions
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using

        Using conn As New SqlConnection(connectionString)
            Using cmd3 As New SqlCommand(query2, conn)
                cmd3.Parameters.AddWithValue("@dateSche", dateSche)
                cmd3.Parameters.AddWithValue("@startT", startT)
                cmd3.Parameters.AddWithValue("@endT", endT)

                Try
                    conn.Open()
                    ' Execute the query
                    cmd3.ExecuteNonQuery()
                Catch ex As Exception
                    ' Handle any exceptions
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using

        Using conn As New SqlConnection(connectionString)
            Using cmd4 As New SqlCommand(query3, conn)
                cmd4.Parameters.AddWithValue("@EventName", eventN)
                cmd4.Parameters.AddWithValue("@Venue", venue)
                cmd4.Parameters.AddWithValue("@DateBooked", dateSche)
                cmd4.Parameters.AddWithValue("@StartTime", startT)
                cmd4.Parameters.AddWithValue("@EndTime", endT)

                Try
                    conn.Open()
                    ' Execute the query
                    cmd4.ExecuteNonQuery()
                Catch ex As Exception
                    ' Handle any exceptions
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using

        Using conn As New SqlConnection(connectionString)
            Using cmd5 As New SqlCommand(query4, conn)
                cmd5.Parameters.AddWithValue("@name", name)
                cmd5.Parameters.AddWithValue("@contact", contact)
                cmd5.Parameters.AddWithValue("@Email", email)
                cmd5.Parameters.AddWithValue("@EventName", eventN)
                cmd5.Parameters.AddWithValue("@Venue", venue)
                cmd5.Parameters.AddWithValue("@Attendees", attendee)
                cmd5.Parameters.AddWithValue("@Type", eventType)
                cmd5.Parameters.AddWithValue("@DateBooked", dateSche)
                cmd5.Parameters.AddWithValue("@StartTime", startT)
                cmd5.Parameters.AddWithValue("@EndTime", endT)

                Try
                    conn.Open()
                    ' Execute the query
                    cmd5.ExecuteNonQuery()
                Catch ex As Exception
                    ' Handle any exceptions
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
        MsgBox("Form Submitted")
        nameInfo.Text = ""
        conInfo.Text = ""
        emailInfo.Text = ""
        eventName.Text = ""
        attendeeCo.Text = ""
        cmbType.SelectedIndex = -1
        cmbvenue.SelectedIndex = -1


    End Sub

    Private Sub LoadData()
        ' Define the SQL query to retrieve data
        Dim query As String = "SELECT * FROM g6_BookedVenue" ' Replace with your table name

        ' Create a SqlConnection and SqlDataAdapter
        Using connection As New SqlConnection(connectionString)
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dataTable As New DataTable()

            Try
                ' Open the connection
                connection.Open()

                ' Fill the DataTable with data from the database
                adapter.Fill(dataTable)

                ' Bind the DataTable to the DataGridView
                DataGridView1.DataSource = dataTable
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadData()
    End Sub
End Class