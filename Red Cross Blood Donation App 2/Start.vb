' Start.vb (Main Form)
Imports System.Data.SqlClient

Public Class Start
    Public frmhelper As New FormHelper


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the connection (if needed)
        'frmhelper.Seeders()
        UpdateConnectionString()
        openConn("redcrossdb") ' Specify database name directly if db_name is undefined
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        Me.Hide()
        Admin_Access.Show()
    End Sub

    Private Sub btnHealthcareprovider_Click(sender As Object, e As EventArgs) Handles btnHealthcareprovider.Click
        Me.Hide()
        HealthCare_Access.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        SuperAdmin_Access.Show()
    End Sub
End Class

' donorsummary.vb (separate class file)
Public Class donorsummary
    ' define your connection string (use your actual connection string)
    Dim connectionstring As String = "server=localhost;database=redcrossdb;uid=root;pwd=;"

    Public Sub getdonorsummaryandinserttohistory(donorid As Integer)
        ' create the sql query to get the required data
        Dim query As String = "
        select 
            d.donorid,
            sum(e.eligibilitycheck) as totaleligibilitycheck,
            count(distinct don.donationid) as totaldonation,
            sum(don.bloodvolume_wholeblood) as totalbloodvolume_wholeblood,
            sum(don.bloodvolume_redblood) as totalbloodvolume_redblood,
            sum(don.bloodvolume_platelets) as totalbloodvolume_platelets,
            sum(don.bloodvolume_plasma) as totalbloodvolume_plasma,
            sum(don.bloodvolume_whiteblood) as totalbloodvolume_whiteblood,
            d.lastname,
            d.firstname,
            d.middlename,
            sum(don.bloodvolume_wholeblood + don.bloodvolume_redblood + don.bloodvolume_platelets + don.bloodvolume_plasma + don.bloodvolume_whiteblood) as totalbloodvolume_all,
            d.donorregdate,
            max(e.lasteligibilitycheckdate) as lasteligibilitycheckdate,
            max(don.donationdate) as latestdonationdate
        from donors d
        left join eligibility e on d.donorid = e.donorid
        left join donations don on d.donorid = don.donorid
        where d.donorid = @donorid
        group by d.donorid, d.lastname, d.firstname, d.middlename, d.donorregdate"

        ' establish a connection to the database
        Using conn As New SqlConnection(connectionstring)
            Try
                conn.Open()

                ' create a command to execute the sql query
                Using cmd As New SqlCommand(query, conn)
                    ' add the parameter for donorid to prevent sql injection
                    cmd.Parameters.AddWithValue("@donorid", donorid)

                    ' execute the query and retrieve the data
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            While reader.Read()
                                ' retrieve the data from the reader
                                Dim retrieveddonorid = reader("donorid")
                                Dim totaleligibilitycheck = reader("totaleligibilitycheck")
                                Dim totaldonation = reader("totaldonation")
                                Dim totalbloodvolumewholeblood = reader("totalbloodvolume_wholeblood")
                                Dim totalbloodvolumeredblood = reader("totalbloodvolume_redblood")
                                Dim totalbloodvolumeplatelets = reader("totalbloodvolume_platelets")
                                Dim totalbloodvolumeplasma = reader("totalbloodvolume_plasma")
                                Dim totalbloodvolumewhiteblood = reader("totalbloodvolume_whiteblood")
                                Dim lastname = reader("lastname")
                                Dim firstname = reader("firstname")
                                Dim middlename = reader("middlename")
                                Dim totalbloodvolumeall = reader("totalbloodvolume_all")
                                Dim donorregdate = reader("donorregdate")
                                Dim lasteligibilitycheckdate = reader("lasteligibilitycheckdate")
                                Dim latestdonationdate = reader("latestdonationdate")

                                ' prepare the sql insert statement for the history table
                                Dim insertquery As String = "
insert into history (
    donorid,
    totaleligibilitycheck,
    totaldonation,
    totalbloodvolume_wholeblood,
    totalbloodvolume_redblood,
    totalbloodvolume_platelets,
    totalbloodvolume_plasma,
    totalbloodvolume_whiteblood,
    lastname,
    firstname,
    middlename,
    totalbloodvolume_all,
    donorregdate,
    lasteligibilitycheckdate,
    latestdonationdate
) values (
    @donorid,
    @totaleligibilitycheck,
    @totaldonation,
    @totalbloodvolume_wholeblood,
    @totalbloodvolume_redblood,
    @totalbloodvolume_platelets,
    @totalbloodvolume_plasma,
    @totalbloodvolume_whiteblood,
    @lastname,
    @firstname,
    @middlename,
    @totalbloodvolume_all,
    @donorregdate,
    @lasteligibilitycheckdate,
    @latestdonationdate
)"

                                ' create the insert command
                                Using insertcmd As New SqlCommand(insertquery, conn)
                                    ' add parameters to the insert command
                                    insertcmd.Parameters.AddWithValue("@donorid", retrieveddonorid)
                                    insertcmd.Parameters.AddWithValue("@totaleligibilitycheck", totaleligibilitycheck)
                                    insertcmd.Parameters.AddWithValue("@totaldonation", totaldonation)
                                    insertcmd.Parameters.AddWithValue("@totalbloodvolume_wholeblood", totalbloodvolumewholeblood)
                                    insertcmd.Parameters.AddWithValue("@totalbloodvolume_redblood", totalbloodvolumeredblood)
                                    insertcmd.Parameters.AddWithValue("@totalbloodvolume_platelets", totalbloodvolumeplatelets)
                                    insertcmd.Parameters.AddWithValue("@totalbloodvolume_plasma", totalbloodvolumeplasma)
                                    insertcmd.Parameters.AddWithValue("@totalbloodvolume_whiteblood", totalbloodvolumewhiteblood)
                                    insertcmd.Parameters.AddWithValue("@lastname", lastname)
                                    insertcmd.Parameters.AddWithValue("@firstname", firstname)
                                    insertcmd.Parameters.AddWithValue("@middlename", middlename)
                                    insertcmd.Parameters.AddWithValue("@totalbloodvolume_all", totalbloodvolumeall)
                                    insertcmd.Parameters.AddWithValue("@donorregdate", donorregdate)
                                    insertcmd.Parameters.AddWithValue("@lasteligibilitycheckdate", lasteligibilitycheckdate)
                                    insertcmd.Parameters.AddWithValue("@latestdonationdate", latestdonationdate)

                                    ' execute the insert command and check for any errors
                                    Try
                                        insertcmd.ExecuteNonQuery()
                                        Console.WriteLine("data inserted successfully!")
                                    Catch ex As Exception
                                        ' output the error message if something goes wrong
                                        Console.WriteLine("error inserting data: " & ex.Message)
                                    End Try
                                End Using

                            End While
                        Else
                            Console.WriteLine("no data found for the specified donorid.")
                        End If
                    End Using
                End Using

            Catch ex As Exception
                ' handle any errors that might occur
                Console.WriteLine($"error: {ex.Message}")
            End Try
        End Using
    End Sub

End Class
