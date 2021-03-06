

SELECT ap.Id
,ap.[Username]
,ap.[Status]
,ap.[ApplicationDate]
,ap.[Name]
,ap.[LastName]
,ap.[BirthPlace]
,ap.[Nationality]
,ap.[BirthDate]
,ap.[Sex]
,ap.[Address]
,ap.[PhoneHouse]
,ap.[PhoneCell]
,ap.[ReferencedByEmployeeCode]
,apd.ExpectedSalary
,apd.GradingLvlId
,job.Name
FROM [dbo].[Applicants] ap
INNER JOIN [dbo].[ApplicantDetails] apd ON ap.Id = apd.ApplicantId
INNER JOIN [dbo].[JobOffers] job ON ap.JobOffer_Id = job.Id

SELECT emp.Id
,emp.[Status]
,emp.RegisteredDate
,emp.[Name]
,emp.[LastName]
,emp.[BirthPlace]
,emp.[Nationality]
,emp.[BirthDate]
,emp.[Sex]
,emp.[Address]
,emp.[PhoneHouse]
,emp.[PhoneCell]
,empd.Salary
,empd.GradingLvlId
,pos.Name
FROM [dbo].Employees emp
INNER JOIN [dbo].EmployeeDetails empd ON emp.Id = empd.[EmployeeId]
INNER JOIN [dbo].EmployeePositions pos ON emp.PositionId = pos.Id

SELECT *
FROM dbo.PersonLinkedDetails
SELECT *
FROM dbo.PersonLinkedGradings
SELECT *
FROM dbo.PersonLinkedWorkingExperiences


-- Applicant Basic details

SELECT ap.[Username]
,ap.[Status]
,ap.[ApplicationDate]
,ap.[Name]
,ap.[LastName]
,ap.[BirthPlace]
,ap.[BirthDate]
,(CASE ap.[Sex] WHEN 1 THEN 'Hombre' ELSE 'Mujer' END) as [Sex] 
,ap.[Address]
,ap.[PhoneHouse]
,ap.[PhoneCell]
,ap.[ReferencedByEmployeeCode]
,apd.ExpectedSalary
,apd.GradingLvlId
,job.Name as [JobName]
FROM [dbo].[Applicants] ap
INNER JOIN [dbo].[ApplicantDetails] apd ON ap.Id = apd.ApplicantId
INNER JOIN [dbo].[JobOffers] job ON ap.JobOffer_Id = job.Id


--  Competences

SELECT apd.ApplicantId
,(SELECT Value FROM [dbo].[Catalogs] c WHERE c.Category = 'COMPETENCE' AND c.Category = pd.Category AND c.SubCategoryId = pd.SubCategoryId) as [Competence]
FROM [dbo].[ApplicantDetails] apd
LEFT JOIN dbo.PersonLinkedDetails pd ON apd.ApplicantId = pd.ApplicantDetail_ApplicantId

-- Languages 

SELECT apd.ApplicantId
,(SELECT Value FROM [dbo].[Catalogs] c WHERE c.Category = 'LANGUAGE' AND c.Category = pd.Category AND c.SubCategoryId = pd.SubCategoryId) as [Language]
,(SELECT Value FROM [dbo].[Catalogs] c WHERE c.Category = 'SKILL_LVL' AND c.SubCategoryId = pd.LevelSubCategoryId) as [LanguageLvl]
FROM [dbo].[ApplicantDetails] apd
LEFT JOIN dbo.PersonLinkedDetails pd ON apd.ApplicantId = pd.ApplicantDetail_ApplicantId

-- Estudies / Grading

SELECT apd.ApplicantId
,pg.Description
,pg.Institution
,pg.FromDate
,pg.ToDate
FROM [dbo].[ApplicantDetails] apd
INNER JOIN dbo.PersonLinkedGradings pg ON apd.ApplicantId = pg.ApplicantDetail_ApplicantId

-- Working Experiences

SELECT apd.ApplicantId
,pwe.CompanyName
,pwe.Description
,pwe.FromDate
,pwe.ToDate
FROM [dbo].[ApplicantDetails] apd
INNER JOIN dbo.PersonLinkedWorkingExperiences pwe ON apd.ApplicantId = pwe.ApplicantDetail_ApplicantId


delete from dbo.PersonLinkedDetails
WHERE EmployeeDetail_EmployeeId = 4;

delete from dbo.PersonLinkedGradings
WHERE EmployeeDetail_EmployeeId = 4;

delete from dbo.PersonLinkedWorkingExperiences
WHERE EmployeeDetail_EmployeeId = 4;

delete from [dbo].[EmployeeDetails]
WHERE EmployeeId = 4;

delete from  [dbo].[Employees]
WHERE Id =4;