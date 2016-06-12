
DECLARE @applicantId int;

CREATE TABLE #TempLinkedDetails
(ApplicantId int NOT NULL, Category varchar(20), Field1 varchar(50), Field2 varchar(50), [From] DateTime, [To] DateTime)

DECLARE applicantId_cursor CURSOR  
    FOR SELECT Id FROM [dbo].[Applicants] WHERE Status = 1

OPEN applicantId_cursor  
FETCH NEXT FROM applicantId_cursor INTO @applicantId; 

	WHILE @@FETCH_STATUS = 0  
	BEGIN  
       
		PRINT @applicantId 
		
		
		INSERT INTO #TempLinkedDetails (ApplicantId, Category, Field1, Field2, [From], [To])
		SELECT apd.ApplicantId, 'Estudios'
		,pg.Description
		,pg.Institution
		,pg.FromDate
		,pg.ToDate
		FROM [dbo].[ApplicantDetails] apd
		INNER JOIN dbo.PersonLinkedGradings pg ON apd.ApplicantId = pg.ApplicantDetail_ApplicantId
		WHERE apd.ApplicantId = @applicantId;

		INSERT INTO #TempLinkedDetails (ApplicantId, Category, Field1, Field2, [From], [To])
		SELECT apd.ApplicantId, 'Experiencia Laboral'
		,pwe.CompanyName
		,pwe.Description
		,pwe.FromDate
		,pwe.ToDate
		FROM [dbo].[ApplicantDetails] apd
		INNER JOIN dbo.PersonLinkedWorkingExperiences pwe ON apd.ApplicantId = pwe.ApplicantDetail_ApplicantId
		WHERE apd.ApplicantId = @applicantId

		INSERT INTO #TempLinkedDetails (ApplicantId, Category, Field1, Field2)
		SELECT apd.ApplicantId, 'Idiomas'
		,(SELECT Value FROM [dbo].[Catalogs] c WHERE c.Category = 'LANGUAGE' AND c.Category = pd.Category AND c.SubCategoryId = pd.SubCategoryId) 
		,(SELECT Value FROM [dbo].[Catalogs] c WHERE c.Category = 'SKILL_LVL' AND c.SubCategoryId = pd.LevelSubCategoryId) 
		FROM [dbo].[ApplicantDetails] apd
		LEFT JOIN dbo.PersonLinkedDetails pd ON apd.ApplicantId = pd.ApplicantDetail_ApplicantId
		WHERE apd.ApplicantId = @applicantId;

		INSERT INTO #TempLinkedDetails (ApplicantId, Category, Field1)
		SELECT apd.ApplicantId, 'Competencias'
		,(SELECT Value FROM [dbo].[Catalogs] c WHERE c.Category = 'COMPETENCE' AND c.Category = pd.Category AND c.SubCategoryId = pd.SubCategoryId)
		FROM [dbo].[ApplicantDetails] apd
		LEFT JOIN dbo.PersonLinkedDetails pd ON apd.ApplicantId = pd.ApplicantDetail_ApplicantId
		WHERE apd.ApplicantId = @applicantId;

		FETCH NEXT FROM applicantId_cursor INTO @applicantId  
	END  


CLOSE applicantId_cursor
DEALLOCATE applicantId_cursor

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
,det.Category
,det.Field1
,det.Field2
,det.[From]
,det.[To]
FROM [dbo].[Applicants] ap
INNER JOIN [dbo].[ApplicantDetails] apd ON ap.Id = apd.ApplicantId
INNER JOIN [dbo].[JobOffers] job ON ap.JobOffer_Id = job.Id
LEFT JOIN #TempLinkedDetails det ON ap.Id = det.ApplicantId


DROP TABLE #TempLinkedDetails