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

        Dim collectionmethods As String() = {"Manual Collection", "Automatic Collection"}

        Dim civilstatusOptions As String() = {"Single", "Married"}

        Dim nationalityOptions As String() = {"Filipino"}

        Dim occupationsOptions As String() = {"Doctor", "Engineer", "Teacher", "Nurse", "Software Developer", "Police Officer", "Firefighter", "Artist", "Mechanic", "Chef"}

        Dim bagtypeOptions As String() = {"Single Bag", "Double Bag", "Triple Bag", "Quadruple Bag", "Aphresis"}

        Dim companyhospitalnameOptions As String() = {"Leon Hernandez Hospital", "Provincial Hospital", "Lourdes Hospital", "New Doctor's Hospital"}

        Dim personnelNameOptions As String() = {"Dr. Juan Dela Cruz", "Dr. Maria Santos", "Dr. Jose Gomez", "Dr. Ana Lopez", "Dr. Carlos Reyes"}

        Dim retrievalPurposeOptions As String() = {"Patient Data Retrieval", "Blood Donation Records", "Medical History Review", "Donor Eligibility Check",
            "Inventory Status Check", "Emergency Contact Lookup", "Medical Test Results", "Appointment Scheduling"
        }


        Dim rand As New Random()
        Dim currentDateTime As DateTime = DateTime.Now
        Dim substanceligible As Integer = New Random().Next(0, 12)

        ' Loop to generate donor entries
        For i As Integer = 1 To 15 'Change depending on needed data
            ' Generate random details (donor)
            Dim donorID As Integer = i
            Dim regDate As DateTime = DateTime.Now ' Random registration date in the last 4 years copy this .AddDays(-rand.Next(1, 1460))
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
            Dim civilstatus As String = civilstatusOptions(rand.Next(civilstatusOptions.Length))
            Dim nationality As String = nationalityOptions(rand.Next(nationalityOptions.Length))
            Dim occupation As String = occupationsOptions(rand.Next(occupationsOptions.Length))


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
            Dim blood_group As String = bloodType.TrimEnd("+"c, "-"c) ' Extract the blood type (A, B, AB, O)
            Dim rhesusFactor As String = If(bloodType.EndsWith("+"), "Rh+", "Rh-") ' Extract the Rhesus factor
            Dim collectionMethod As String = ""
            Dim bloodVolume As Integer = New Integer() {200, 300, 400, 500, 600}(rand.Next(5))
            Dim donationType As String = New String() {"Whole Blood Donation", "Plasma Donation (Apheresis)", "Platelet Donation (Apheresis)", "Red Blood Cell Donation (Apheresis)", "White Blood Cell Donation (Apheresis)"}(rand.Next(5))
            Dim donationDate As DateTime = regDate.Date
            Dim donationTime As TimeSpan = regDate.TimeOfDay
            Dim randomDays As Integer = rand.Next(1, 31) ' Random number of days between 1 and 30
            Dim nextEligibilityDate As DateTime = regDate.AddMonths(3).AddDays(randomDays)
            Dim expirationDate As DateTime = donationDate.AddDays(42)
            Dim bloodComponent As String = ""

            ' Condition for blood component and Collection method
            If donationType = "Whole Blood Donation" Then
                collectionMethod = "Manual Collection"
                bloodComponent = "Whole Blood"
            ElseIf donationType = "Plasma Donation (Apheresis)" Then
                collectionMethod = "Automatic Collection"
                bloodComponent = "Plasma"
            ElseIf donationType = "Platelet Donation (Apheresis)" Then
                collectionMethod = "Automatic Collection"
                bloodComponent = "Platelets"
            ElseIf donationType = "Red Blood Cell Donation (Apheresis)" Then
                collectionMethod = "Automatic Collection"
                bloodComponent = "Red Blood Cells"
            ElseIf donationType = "White Blood Cell Donation" Then
                collectionMethod = "Automatic Collection"
                bloodComponent = "White Blood Cells"
            Else
                bloodComponent = "Unknown"
            End If

            Dim compatibility As String = ""
            If bloodType = "A+" Then
                compatibility = "A+, AB+"
            ElseIf bloodType = "A-" Then
                compatibility = "A+, A-, AB+, AB-"
            ElseIf bloodType = "B+" Then
                compatibility = "B+, AB+"
            ElseIf bloodType = "B-" Then
                compatibility = "B+, B-, AB+, AB-"
            ElseIf bloodType = "O+" Then
                compatibility = "O+, A+, B+, AB+"
            ElseIf bloodType = "O-" Then
                compatibility = "All Blood Types"
            ElseIf bloodType = "AB+" Then
                compatibility = "AB+"
            ElseIf bloodType = "AB-" Then
                compatibility = "AB+, AB-"
            Else
                compatibility = "Unknown"
            End If

            Dim bagtype As String = bagtypeOptions(rand.Next(bagtypeOptions.Length))

            Dim storagelocation As String = ""
            If donationType = "Whole Blood Donation" Or donationType = "Red Blood Cell Donation (Apheresis)" Then
                storagelocation = "Refrigerated Storage"
            ElseIf donationType = "Plasma Donation (Apheresis)" Then
                storagelocation = "Frozen Storage"
            ElseIf donationType = "Platelet Donation (Apheresis)" Then
                storagelocation = "Platelet Storage"
            ElseIf donationType = "White Blood Cell Donation (Apheresis" Then
                storagelocation = "White Blood Cell Storage"
            Else
                storagelocation = "Unknown"
            End If


            ' Generate Random details (HealthProvider)
            Dim retrieveID As Integer = i
            Dim healthproviderID As Integer = i
            Dim companyhospitalname As String = companyhospitalnameOptions(rand.Next(companyhospitalnameOptions.Length))
            Dim personelID As Integer = i
            Dim PersonelName As String = personnelNameOptions(rand.Next(personnelNameOptions.Length))
            Dim PurposeofRetrieval As String = retrievalPurposeOptions(rand.Next(retrievalPurposeOptions.Length))
            Dim prefixes As String() = {"091", "092", "093", "094", "095", "096", "097", "098", "099"}

            ' Randomly select a prefix
            Dim selectedPrefix As String = prefixes(rand.Next(prefixes.Length))

            ' Generate the rest of the contact number (7 digits)
            Dim contactNumber As String = selectedPrefix & rand.Next(1000000, 9999999).ToString()
            Dim nameParts As String() = {"admin", "info", "support", "contact"}

            ' Randomly select a hospital and an email name part
            Dim selectedHospital As String = companyhospitalnameOptions(rand.Next(companyhospitalnameOptions.Length))
            Dim namePart As String = nameParts(rand.Next(nameParts.Length))

            ' Generate the email address based on the selected hospital
            Dim emailAddress As String = namePart & "@" & selectedHospital.Replace(" ", "").ToLower() & ".com"
            Dim retrieveDate As DateTime = regDate



            Dim connectionString As String = "Server=localhost;Database=redcrossdb;Uid=root;Pwd=;"
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim transaction As MySqlTransaction = connection.BeginTransaction()

                Try


                    ' Insert the new donor data
                    Dim query As String = "INSERT INTO donors (LastName, FirstName, MiddleName, Baranggay, City, Province, DateofBirth, Age, Sex, BloodType, RegDate, CivilStatus, Nationality, Occupation) " &
                                          "VALUES (@LastName, @FirstName, @MiddleName, @Baranggay, @City, @Province, @DateOfBirth, @Age, @Sex, @BloodType, @RegDate, @CivilStatus, @Nationality, @Occupation)"
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
                        cmd.Parameters.AddWithValue("@CivilStatus", civilstatus)
                        cmd.Parameters.AddWithValue("@Nationality", nationality)
                        cmd.Parameters.AddWithValue("@Occupation", occupation)

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
                    Dim donationQuery As String = "INSERT INTO donation (BloodID, DonorID, Blood_Group, RhesusFactor, CollectionMethod, BloodVolume, DonationType, " &
                                                  "DonationDate, DonationTime, NextEligibilityDate, Expiration_Date, BloodComponent, Compatibility, BagType, StorageLocation) " &
                                                  "VALUES (@BloodID, @DonorID, @Blood_Group, @RhesusFactor, @CollectionMethod, @BloodVolume, @DonationType, " &
                                                  "@DonationDate, @DonationTime, @NextEligibilityDate, @Expiration_Date, @BloodComponent, @Compatibility, @BagType, @StorageLocation)"
                    Using cmdDonation As New MySqlCommand(donationQuery, connection)
                        cmdDonation.Parameters.AddWithValue("@BloodID", bloodID)
                        cmdDonation.Parameters.AddWithValue("@DonorID", donorID)
                        cmdDonation.Parameters.AddWithValue("@Blood_Group", blood_group)
                        cmdDonation.Parameters.AddWithValue("@RhesusFactor", rhesusFactor)
                        cmdDonation.Parameters.AddWithValue("@CollectionMethod", collectionMethod)
                        cmdDonation.Parameters.AddWithValue("@BloodVolume", bloodVolume)
                        cmdDonation.Parameters.AddWithValue("@DonationType", donationType)
                        cmdDonation.Parameters.AddWithValue("@DonationDate", donationDate)
                        cmdDonation.Parameters.AddWithValue("@DonationTime", donationTime)
                        cmdDonation.Parameters.AddWithValue("@NextEligibilityDate", nextEligibilityDate)
                        cmdDonation.Parameters.AddWithValue("@Expiration_Date", expirationDate)
                        cmdDonation.Parameters.AddWithValue("@BloodComponent", bloodComponent)
                        cmdDonation.Parameters.AddWithValue("@Compatibility", compatibility)
                        cmdDonation.Parameters.AddWithValue("@BagType", bagtype)
                        cmdDonation.Parameters.AddWithValue("@StorageLocation", storagelocation)

                        ' Execute the donation query
                        cmdDonation.ExecuteNonQuery()
                    End Using

                    ' Insert into healthprovider table
                    Dim healthProviderQuery As String = "INSERT INTO healthprovider (RetrieveID, HealthProviderID, CompanyHospitalName, PersonnelID, PersonnelName, BloodID, LastName, FirstName, MiddleName, Blood_Group, RhesusFactor, DonationType, BloodVolume, RetrieveDate, PurposeOfRetrieval, ContactNo, EmailAdd) " &
                                    "VALUES (@retrieveID, @healthproviderID, @companyhospitalname, @personelID, @personelName, @BloodID, @LastName, @FirstName, @MiddleName, @Blood_Group, @RhesusFactor, @DonationType, @BloodVolume, @RetrieveDate, @purposeOfRetrieval, @contactNumber, @EmailAdd)"

                    Using cmdHealthProvider As New MySqlCommand(healthProviderQuery, connection)
                        ' Add parameters for health provider details
                        cmdHealthProvider.Parameters.AddWithValue("@retrieveID", retrieveID)
                        cmdHealthProvider.Parameters.AddWithValue("@healthproviderID", healthproviderID)
                        cmdHealthProvider.Parameters.AddWithValue("@companyhospitalname", companyhospitalname)
                        cmdHealthProvider.Parameters.AddWithValue("@personelID", personelID)
                        cmdHealthProvider.Parameters.AddWithValue("@personelName", PersonelName)
                        cmdHealthProvider.Parameters.AddWithValue("@purposeOfRetrieval", PurposeofRetrieval)
                        cmdHealthProvider.Parameters.AddWithValue("@contactNumber", contactNumber)
                        cmdHealthProvider.Parameters.AddWithValue("@EmailAdd", emailAddress)
                        cmdHealthProvider.Parameters.AddWithValue("@RetrieveDate", regDate)

                        ' Add parameters for blood details
                        cmdHealthProvider.Parameters.AddWithValue("@BloodID", bloodID)
                        cmdHealthProvider.Parameters.AddWithValue("@LastName", lastName)
                        cmdHealthProvider.Parameters.AddWithValue("@FirstName", firstName)
                        cmdHealthProvider.Parameters.AddWithValue("@MiddleName", middleName)
                        cmdHealthProvider.Parameters.AddWithValue("@Blood_Group", blood_group) ' Ensure this matches the variable name
                        cmdHealthProvider.Parameters.AddWithValue("@RhesusFactor", rhesusFactor)
                        cmdHealthProvider.Parameters.AddWithValue("@DonationType", donationType)
                        cmdHealthProvider.Parameters.AddWithValue("@BloodVolume", bloodVolume)

                        ' Execute the healthprovider query
                        cmdHealthProvider.ExecuteNonQuery()
                    End Using

                    ' Your database operations here
                    ' Commit the transaction
                    transaction.Commit()
                Catch ex As MySqlException
                    transaction.Rollback()
                    MessageBox.Show("MySQL Error: " & ex.Message)
                    Console.WriteLine("Error in transaction for donor ID: " & i)
                Catch ex As Exception
                    transaction.Rollback()
                    MessageBox.Show("General Error: " & ex.Message)
                End Try




            End Using
        Next
    End Sub
    Public Function RandomBloodpressure() As String
        ' Random blood pressure values within normal range
        Dim systolic As Integer = (New Random()).Next(90, 121)
        Dim diastolic As Integer = (New Random()).Next(60, 81)
        Return $"{systolic}/{diastolic}"
    End Function

    Public Function RandomHemoglobin(sex As String) As Double
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
