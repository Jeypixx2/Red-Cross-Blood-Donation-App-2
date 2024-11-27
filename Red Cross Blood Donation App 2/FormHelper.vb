Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class FormHelper

    Public Sub Seeders()
        Dim firstnames As String() = {
            "Juan", "Pedro", "Byron", "Taylor", "Bogart", "Alice", "Bob", "Charlie", "David", "Eva",
            "Francis", "Grace", "Hannah", "Igor", "Jack", "Katherine", "Liam", "Mason", "Nina", "Oscar",
            "Paul", "Quinn", "Rachel", "Sarah", "Tim", "Uma", "Victor", "Wendy", "Xander", "Yara",
            "Zane", "Abigail", "Benjamin", "Catherine", "Daniel", "Emily", "Felix", "George", "Holly", "Ivy",
            "James", "Kendall", "Lily", "Max", "Nora", "Oliver", "Penny", "Quincy", "Riley", "Sophia",
            "Toby", "Ursula", "Vera", "Walter", "Ximena", "Yasmine", "Zoe", "Amelia", "Brandon", "Chloe",
            "Dylan", "Ella", "Fiona", "Gavin", "Harrison", "Isla", "Jasmine", "Kyle", "Laura", "Maya",
            "Nathan", "Owen", "Priscilla", "Quinn", "Reagan", "Samuel", "Tina", "Ulysses", "Vanessa", "Willow",
            "Xander", "Yusuf", "Zane", "Addison", "Bryce", "Clara", "Dean", "Eleanor", "Freddy", "Gage",
            "Holly", "Isabel", "Jackson", "Kendra", "Logan", "Maya", "Nolan", "Olivia", "Piper", "Quinn",
            "Ruby", "Sean", "Tess", "Umar", "Violet", "Weston", "Xander", "Yvonne", "Zachary", "Aidan",
            "Beatrice", "Cameron", "Daisy", "Ethan", "Felicity", "Gage", "Heather", "Ian", "Jameson", "Katie"
        }

        Dim lastnames As String() = {
            "Dela Cruz", "San Juan", "Sheeran", "Garcia", "Esperanza", "Smith", "Johnson", "Williams", "Brown", "Jones",
            "Miller", "Davis", "García", "Rodriguez", "Martínez", "Hernández", "Lopez", "González", "Perez", "Sánchez",
            "Ramírez", "Torres", "Fernández", "López", "Mendoza", "Morales", "Gomez", "Ruiz", "Alvarez", "Soto",
            "Vargas", "Gutiérrez", "Jiménez", "Moya", "Pérez", "Delgado", "Navarro", "Ortega", "Vega", "Castillo",
            "Chavez", "Jimenez", "Cameron", "Lynch", "Cameron", "Harris", "Mason", "Taylor", "Evans", "Riley",
            "Baker", "Mitchell", "Young", "Morgan", "Campbell", "Reed", "Scott", "Murphy", "Morgan", "Coleman",
            "Roberts", "Collins", "Foster", "Sanders", "Graham", "Bell", "Watson", "Morris", "Peterson", "Hunter",
            "Ward", "Ross", "Bennett", "King", "Cook", "Stewart", "Adams", "Nelson", "Parker", "Morris",
            "Cooper", "Price", "Powell", "Bellamy", "George", "Mitchell", "Reyes", "Bryant", "Green", "Mitchell",
            "Richards", "Hughes", "Knight", "Graham", "Day", "Holland", "Butler", "Perry", "Fisher", "Dixon",
            "Simmons", "Bryant", "Stevenson", "Wallace", "Ford", "Duncan", "Woods", "Henderson", "Stewart", "Carson",
            "Wright", "Palmer", "Moreno", "Cameron", "Carroll", "Curtis", "Lamar", "Webb", "Sullivan", "Phillips",
            "Robinson", "Chapman", "Garrett", "Banks", "Jackson", "Morris"
        }

        Dim middlenames As String() = {
            "Marie", "James", "Lee", "Ann", "Grace", "John", "Lynn", "Rose", "Allen", "Michael",
            "David", "Louise", "William", "Elizabeth", "Patrick", "Evelyn", "George", "Ray", "Samantha", "Joseph",
            "Diane", "Thomas", "Eugene", "Claire", "Paul", "Renee", "Thomas", "Catherine", "Arthur", "June",
            "Victor", "Ruth", "Henry", "Charlotte", "Eleanor", "Benjamin", "Madeline", "Mark", "Kate", "Alice",
            "Hannah", "Isabelle", "Oscar", "Vanessa", "Charles", "Madison", "Andrew", "Jane", "Frank", "Jean",
            "Abigail", "Scott", "Grace", "Beverly", "Samuel", "Naomi", "Kenneth", "Zoe", "Maxine", "Dean",
            "Sophie", "Riley", "Keith", "Megan", "Tracy", "Jackson", "Deborah", "Emma", "Toby", "Vivian",
            "Timothy", "Caroline", "Frederick", "Katherine", "Zachary", "Norma", "Harrison", "Lily", "Isaac",
            "Nina", "Cheryl", "Lucas", "Vera", "Isla", "Patrick", "Monica", "Joshua", "Lori", "Cora",
            "Megan", "Peter", "Sally", "Deborah", "Lucas", "Rosemary", "Edwin", "Gwendolyn", "Eli", "Audrey",
            "Morris", "Seth", "Carson", "Jessica", "Alexander", "Olivia", "Luke", "Beatrice", "Julian", "Melanie",
            "Doris", "Walter", "Annie", "Levi", "Briana", "Penny", "Sarah", "Harold", "Genevieve", "Clark",
            "Vera", "Jared", "Bernice", "Elias", "Judith", "Simon", "Esther", "Fiona", "Irene", "Douglas"
            }


        Dim barangays As String() = {
            "Barangay 1", "Barangay 2", "Barangay 3", "Barangay 4", "Barangay 5", "Barangay Santo Niño", "Barangay Poblacion",
            "Barangay San Isidro", "Barangay San Pedro", "Barangay Bagumbayan", "Barangay Mabini", "Barangay Maligaya",
            "Barangay Kalayaan", "Barangay Laging Handa", "Barangay Dolores", "Barangay Don Antonio", "Barangay Tatalon",
            "Barangay Culiat", "Barangay Quezon Hill", "Barangay Holy Spirit", "Barangay Commonwealth", "Barangay San Juan",
            "Barangay New Era", "Barangay Nangka", "Barangay Pag-asa", "Barangay Muzon", "Barangay Damar", "Barangay San Francisco",
            "Barangay Malate", "Barangay Bel-Air", "Barangay Makati", "Barangay Sta. Mesa", "Barangay Catmon", "Barangay Palingon",
            "Barangay Panghulo", "Barangay Bagumbayan", "Barangay Cagayan", "Barangay Maybunga", "Barangay North Triangle", "Barangay South Triangle",
            "Barangay Ugong", "Barangay Valenzuela", "Barangay Bangkal", "Barangay Paco", "Barangay Bel-Air", "Barangay Silang",
            "Barangay Santo Tomas", "Barangay San Sebastian", "Barangay Sampaloc", "Barangay Mulawin", "Barangay Tahanan",
            "Barangay Baño", "Barangay Tanauan", "Barangay Sta. Cruz", "Barangay Manggahan", "Barangay Quirino", "Barangay Subangdaku",
            "Barangay Cuenca", "Barangay Sto. Niño", "Barangay Inarawan", "Barangay Davao", "Barangay Alabang", "Barangay Pangarap",
            "Barangay Pansol", "Barangay Sikatuna", "Barangay Poblacion", "Barangay San Vicente", "Barangay Kamuning",
            "Barangay Bahay Toro", "Barangay San Dionisio", "Barangay Casimiro", "Barangay Sampaloc", "Barangay Salcedo",
            "Barangay Buhangin", "Barangay Libis", "Barangay Tumana", "Barangay Katipunan", "Barangay Concepcion", "Barangay Pugadlawin",
            "Barangay Maharlika", "Barangay Pasong Tamo", "Barangay Kamias", "Barangay San Juan", "Barangay Sto. Rosario",
            "Barangay Ilaya", "Barangay San Pedro", "Barangay Dela Paz", "Barangay Violeta", "Barangay New Manila",
            "Barangay Batangas", "Barangay Inocencio", "Barangay Soro-Soro", "Barangay Sampaguita", "Barangay Pablito",
            "Barangay Sangandaan", "Barangay Pasig", "Barangay F. Manalo", "Barangay Northgate", "Barangay San Bartolome",
            "Barangay Pilar", "Barangay Marikina", "Barangay Pasay", "Barangay Quiapo", "Barangay Paliparan",
            "Barangay Talisay", "Barangay Sabang", "Barangay San Rafael", "Barangay Dalig", "Barangay Estrella",
            "Barangay Gagalangin", "Barangay Singkamas", "Barangay San Andres", "Barangay Dinas", "Barangay Ligid",
            "Barangay Tagumpay", "Barangay Lumbang", "Barangay Old Balara", "Barangay Mahipon", "Barangay Kaginhawaan"
        }

        Dim cities As String() = {
            "Manila", "Quezon City", "Makati", "Cebu City", "Davao City", "Taguig", "Pasig", "Mandaluyong", "Marikina", "Parañaque",
            "Calamba", "Antipolo", "Angeles City", "Bacolod", "Baguio", "Iloilo City", "Zamboanga City", "Cagayan de Oro", "General Santos",
            "Tacloban", "San Fernando", "Tagbilaran", "Butuan", "Tarlac City", "Laguna", "Subic", "Batangas City", "Bacolor", "Malabon",
            "Las Piñas", "Cebu", "Dumaguete", "Dipolog", "Lucena", "Taguig", "Cabanatuan", "Cotabato City", "Tagaytay", "Muntinlupa",
            "Navotas", "Taytay", "San Juan", "Makati City", "Caloocan", "Valenzuela", "Marinduque", "Cavite City", "Talisay City", "Bacolod",
            "Mati", "Surigao", "Naga", "Zamboanga del Norte", "Cebu City", "Muntinlupa", "Taguig", "Pasay", "Cebu City", "Iligan City",
            "Olongapo", "Sorsogon", "Mandaluyong", "Dumaguete", "Bicol", "Digos", "Palawan", "San Pedro", "Baguio City", "Manila City",
            "Tarlac", "Legazpi", "Vigan", "Binangonan", "Calapan", "Minglanilla", "Marinduque", "San Mateo", "Olongapo City", "Digos City",
            "Marikina", "Malolos", "Quezon City", "Batangas", "Dasmariñas", "Bulan", "Santiago", "San Pablo", "Tagum", "Hagonoy", "Mati"
        }

        Dim provinces As String() = {
            "Metro Manila", "Cebu", "Davao del Sur", "Iloilo", "Negros Occidental", "Batangas", "Pangasinan", "Bulacan", "Laguna",
            "Cavite", "Zamboanga del Sur", "Misamis Oriental", "Leyte", "Sorsogon", "Camarines Sur", "Tarlac", "Isabela", "Bohol",
            "Quezon", "Rizal", "Nueva Ecija", "Cotabato", "Nueva Vizcaya", "Bukidnon", "Surigao del Sur", "Palawan", "Antique",
            "North Cotabato", "Southern Leyte", "Bicol", "Abra", "Kalinga", "Ifugao", "La Union", "Mountain Province", "Tawi-Tawi",
            "Zamboanga del Norte", "Davao de Oro", "Negros Oriental", "Misamis Occidental", "Eastern Samar", "Occidental Mindoro",
            "Camiguin", "Cagayan", "Sultan Kudarat", "Maguindanao", "Batangas", "Ilocos Norte", "Ilocos Sur", "Benguet", "Marinduque",
            "Guimaras", "Siquijor", "Tarlac", "Samar", "Antique", "Masbate", "Leyte", "Capiz", "Albay", "Lanao del Norte", "Basilan",
            "Agusan del Norte", "Agusan del Sur", "Negros del Norte", "Surigao del Norte", "Zamboanga Sibugay", "Davao Oriental",
            "Southern Mindanao", "Northern Samar", "Surigao", "Davao del Norte", "Lanao del Sur", "Zamboanga del Sur", "Rizal",
            "Siquijor", "Cagayan de Oro", "Bohol", "Sorsogon", "Zamboanga del Norte", "Bataan", "Cebu", "Camiguin", "Batangas",
            "Iloilo", "Tawi-Tawi", "Kalinga", "Batanes", "La Union", "Benguet", "Cagayan", "Northern Samar", "Basilan", "Lanao del Norte",
            "Maguindanao", "Cebu", "Cagayan", "Lanao del Sur", "Bohol", "Isabela", "Surigao del Sur", "Davao Oriental", "Cebu", "Agusan del Sur"
        }


        Dim bloodtypes As String() = {"A+", "B+", "AB+", "O+", "A-", "B-", "AB-", "O-"}

        Dim collectionmethods As String() = {""}




        Dim rand As New Random()
        Dim currentDateTime As DateTime = DateTime.Now
        Dim substanceligible As Integer = New Random().Next(0, 12)

        ' Loop to generate 100 donor entries
        For i As Integer = 1 To 10000
            ' Generate random details (donor)
            Dim donorID As Integer = i
            Dim regDate As DateTime = DateTime.Now.AddDays(-rand.Next(1, 1460)) ' Random registration date in the last 4 years
            Dim regDateStr As String = regDate.ToString("yyyy-MM-dd") ' String version if needed
            Dim lastName As String = lastnames(rand.Next(lastnames.Length))
            Dim firstName As String = firstnames(rand.Next(firstnames.Length))
            Dim middleName As String = middlenames(rand.Next(middlenames.Length))
            Dim barangay As String = barangays(rand.Next(barangays.Length))
            Dim city As String = cities(rand.Next(cities.Length))
            Dim province As String = provinces(rand.Next(provinces.Length))
            Dim dateOfBirth As DateTime = DateTime.Now.AddYears(-rand.Next(18, 50)) ' Random age between 18 and 50
            Dim dateOfBirthStr As String = dateOfBirth.ToString("yyyy-MM-dd") ' String version if needed
            Dim age As Integer = regDate.Year - dateOfBirth.Year
            If regDate < dateOfBirth.AddYears(age) Then
                age -= 1
            End If
            Dim sex As String = If(rand.Next(2) = 0, "Male", "Female")
            Dim bloodType As String = bloodtypes(rand.Next(bloodtypes.Length))


            ' Generate random details (eligibility)
            Dim eligiblityID As Integer = i
            Dim weight As Integer = rand.Next(50, 137) ' Generate random weight between 50 and 136 kg
            Dim bloodpressure As String = RandomBloodpressure()
            Dim hemoglobinlevel As Double = RandomHemoglobin(sex)
            Dim conditionCheck As String = 0
            Dim conditionType As String = ""
            Dim substanceCheck As Boolean = rand.Next(2) = 0 ' Random boolean value (True or False)
            Dim substanceDate As Object = If(substanceCheck, regDate.AddDays(-rand.Next(2, 365)), DBNull.Value) ' Random date between 2 days and 1 year before regDate
            Dim tattooCheck As Boolean = rand.Next(2) = 0 ' Random boolean value for tattoo check
            Dim tattooDate As Object = If(tattooCheck, regDate.AddYears(-rand.Next(1, 11)), DBNull.Value) ' Random year between 1 and 10 years ago
            Dim medicationCheck As Boolean = rand.Next(2) = 0 ' Random boolean value for medication check
            Dim medicationDate As Object = If(medicationCheck, regDate.AddDays(-rand.Next(8, 365)), DBNull.Value) ' Random date between 8 days and 1 year before regDate
            Dim eligibilityStatus As String = "1"
            Dim eligibilityDate As DateTime = regDate ' Same as regDate assuming sameday eligibility check
            Dim eligibilityDateStr As String = eligibilityDate.ToString("yyyy-MM-dd") ' String version if needed

            ' Generate random details (donation)
            Dim bloodID As Integer = i
            Dim bloodTypeD As String = bloodType.TrimEnd("+"c, "-"c) ' Extract the blood type (A, B, AB, O)
            Dim rhesusFactor As String = If(bloodType.EndsWith("+"), "Rh+", "Rh-") ' Extract the Rhesus factor
            Dim collectionMethod As String = If(rand.Next(2) = 0, "Manual Collection", "Automatic Collection")
            Dim bloodVolume As Integer = New Integer() {200, 300, 400, 500, 600}(rand.Next(5))
            Dim donationType As String = New String() {"Whole Blood Donation", "Plasma Donation (Apheresis)", "Platelet Donation (Apheresis)", "Red Blood Cell Donation (Apheresis)", "Double Red Cell Donation", "Autologous Donation", "Directed Donation"}(rand.Next(7))
            Dim donationDate As DateTime = regDate.Date
            Dim donationTime As TimeSpan = regDate.TimeOfDay
            Dim randomDays As Integer = rand.Next(1, 31) ' Random number of days between 1 and 30
            Dim nextEligibilityDate As DateTime = regDate.AddMonths(3).AddDays(randomDays)
            Dim numberOfUnits As Integer = rand.Next(1, 5) ' Random number of units between 1 and 4
            Dim expirationDate As DateTime = donationDate.AddDays(42)

            Dim connectionString As String = "Server=localhost;Database=redcrossdb;Uid=root;Pwd=;"
            Using connection As New MySqlConnection(connectionString)
                Try
                    connection.Open()

                    ' Insert the new donor data
                    Dim query As String = "INSERT INTO donors (LastName, FirstName, MiddleName, Baranggay, City, Province, DateofBirth, Age, Sex, BloodType, RegDate) " &
                                  "VALUES (@LastName, @FirstName, @MiddleName, @Baranggay, @City, @Province, @DateOfBirth, @Age, @Sex, @BloodType, @RegDate)"
                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@LastName", lastName)
                        cmd.Parameters.AddWithValue("@FirstName", firstName)
                        cmd.Parameters.AddWithValue("@MiddleName", middleName)
                        cmd.Parameters.AddWithValue("@Baranggay", barangay)
                        cmd.Parameters.AddWithValue("@City", city)
                        cmd.Parameters.AddWithValue("@Province", province)
                        cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth)
                        cmd.Parameters.AddWithValue("@Age", age)
                        cmd.Parameters.AddWithValue("@Sex", sex)
                        cmd.Parameters.AddWithValue("@BloodType", bloodType)
                        cmd.Parameters.AddWithValue("@RegDate", regDate)

                        cmd.ExecuteNonQuery()
                    End Using

                    ' Insert the eligibility data
                    Dim eligibilityQuery As String = "INSERT INTO eligibility (EligibilityID, DonorID, Weight, BloodPressure, Hemoglobin, ConditionCheck, ConditionType, " &
                                             "Substance, SubstanceDate, TattooPiercing, TattooPiercingDate, Medication, MedicationDate, EligibilityStatus, EligibilityDate) " &
                                             "VALUES (@EligibilityID, @DonorID, @Weight, @BloodPressure, @HemoglobinLevel, @ConditionCheck, @ConditionType, " &
                                             "@SubstanceCheck, @SubstanceDate, @TattooCheck, @TattooDate, @MedicationCheck, @MedicationDate, @EligibilityStatus, @EligibilityDate)"
                    Using cmdEligibility As New MySqlCommand(eligibilityQuery, connection)
                        cmdEligibility.Parameters.AddWithValue("@EligibilityID", eligiblityID)
                        cmdEligibility.Parameters.AddWithValue("@DonorID", donorID)
                        cmdEligibility.Parameters.AddWithValue("@Weight", weight)
                        cmdEligibility.Parameters.AddWithValue("@BloodPressure", bloodpressure)
                        cmdEligibility.Parameters.AddWithValue("@HemoglobinLevel", hemoglobinlevel)
                        cmdEligibility.Parameters.AddWithValue("@ConditionCheck", conditionCheck)
                        cmdEligibility.Parameters.AddWithValue("@ConditionType", conditionType)
                        cmdEligibility.Parameters.AddWithValue("@SubstanceCheck", substanceCheck)
                        cmdEligibility.Parameters.AddWithValue("@SubstanceDate", substanceDate)
                        cmdEligibility.Parameters.AddWithValue("@TattooCheck", tattooCheck)
                        cmdEligibility.Parameters.AddWithValue("@TattooDate", tattooDate)
                        cmdEligibility.Parameters.AddWithValue("@MedicationCheck", medicationCheck)
                        cmdEligibility.Parameters.AddWithValue("@MedicationDate", medicationDate)
                        cmdEligibility.Parameters.AddWithValue("@EligibilityStatus", eligibilityStatus)
                        cmdEligibility.Parameters.AddWithValue("@EligibilityDate", eligibilityDate)

                        cmdEligibility.ExecuteNonQuery()
                    End Using

                    ' Insert the donation data
                    Dim donationQuery As String = "INSERT INTO donation (BloodID, DonorID, BloodType, RhesusFactor, CollectionMethod, BloodVolume, DonationType, " &
                               "DonationDate, DonationTime, NextEligibilityDate, Number_Of_Unit, Expiration_Date) " &
                               "VALUES (@BloodID, @DonorID, @BloodType, @RhesusFactor, @CollectionMethod, @BloodVolume, @DonationType, " &
                               "@DonationDate, @DonationTime, @NextEligibilityDate, @Number_Of_Unit, @Expiration_Date)"
                    Using cmdDonation As New MySqlCommand(donationQuery, connection)
                        cmdDonation.Parameters.AddWithValue("@BloodID", bloodID)
                        cmdDonation.Parameters.AddWithValue("@DonorID", donorID)
                        cmdDonation.Parameters.AddWithValue("@BloodType", bloodTypeD)
                        cmdDonation.Parameters.AddWithValue("@RhesusFactor", rhesusFactor)
                        cmdDonation.Parameters.AddWithValue("@CollectionMethod", collectionMethod)
                        cmdDonation.Parameters.AddWithValue("@BloodVolume", bloodVolume)
                        cmdDonation.Parameters.AddWithValue("@DonationType", donationType)
                        cmdDonation.Parameters.AddWithValue("@DonationDate", donationDate)
                        cmdDonation.Parameters.AddWithValue("@DonationTime", donationTime)
                        cmdDonation.Parameters.AddWithValue("@NextEligibilityDate", nextEligibilityDate)
                        cmdDonation.Parameters.AddWithValue("@Number_Of_Unit", numberOfUnits)
                        cmdDonation.Parameters.AddWithValue("@Expiration_Date", expirationDate)

                        cmdDonation.ExecuteNonQuery()
                    End Using
                Catch ex As MySqlException
                    MessageBox.Show("An error occurred: " & ex.Message)
                Catch ex As Exception
                    MessageBox.Show("An unexpected error occurred: " & ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        Next
    End Sub
    Private Function RandomBloodpressure() As String
        ' Random blood pressure values within normal range
        Dim systolic As Integer = (New Random()).Next(90, 121)
        Dim diastolic As Integer = (New Random()).Next(60, 81)
        Return $"{systolic}/{diastolic}"
    End Function

    Private Function RandomHemoglobin(sex As String) As Double
        ' Generate a hemoglobin level based on gender
        Dim random As New Random()
        If sex = "Male" Then
            ' For males, generate hemoglobin between 13.0 and 17.0 g/dL, with eligibility >= 13.0 g/dL
            Return Math.Round(random.NextDouble() * (17.0 - 13.0) + 13.0, 1)
        Else
            ' For females, generate hemoglobin between 12.0 and 16.0 g/dL, with eligibility >= 12.5 g/dL
            Return Math.Round(random.NextDouble() * (16.0 - 12.0) + 12.0, 1)
        End If
    End Function

End Class
