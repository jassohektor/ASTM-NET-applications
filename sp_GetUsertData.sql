use[db]
go

--The stored procedure below is just an example of the lab system db.objects relationship model.
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetUsertData]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[sp_GetUsertData]
GO

CREATE PROC sp_GetUsertData
(@userRequest nVARCHAR(100), @system nVARCHAR(100))
AS
--DECLARE @userRequest nVARCHAR(100), @system nVARCHAR(100)
--SET @userRequest = '10264758';
--SET @system = 'DRL';
DECLARE @requestNo nVARCHAR(100), @branchCode nVARCHAR(100), @barcode nVARCHAR(100);

--Temporary tables
DECLARE @tblEventRequest AS TABLE(UserId INT NOT NULL, RequestDetailId INT, RequestNo INT, branchCode TEXT);
DECLARE @tblUser AS TABLE (UserId INT NOT NULL, UserName TEXT);
DECLARE @tblRequestDetail AS TABLE (RequestDetailId INT NOT NULL, StudioTypeId INT);
DECLARE @tblStudioType AS TABLE (StudioTypeId INT NOT NULL, ParameterId INT);
DECLARE @tblParameters AS TABLE (ParameterId INT NOT NULL, CodeMapId INT, SampleId INT);
DECLARE @tblCodeMap AS TABLE (CodeMapId INT NOT NULL, SystemSample TEXT, System TEXT, Code TEXT);
DECLARE @tblSample AS TABLE (SampleId INT NOT NULL, Barcode TEXT);

--Clinical Chemistry System Instruments:
DECLARE @tblChemistrySystem AS TABLE (ChemistrySystemId INT NOT NULL, Code TEXT);
DECLARE @tblSystemInterface AS TABLE (SystemInterfaceId INT NOT NULL, Code TEXT);

--insert mockup data here!

SET @requestNo	= RIGHT(@userRequest,LEN(@userRequest) - 3)
SET @branchCode	= LEFT(@userRequest, 1)
SET @barcode	= RIGHT(LEFT(@userRequest,3), 2)

SELECT us.[UserName], cm.[SystemSample], cm.[Code] as [studio]
FROM @tblEventRequest	er
	JOIN @tblUser 			us		ON us.[UserId]			= er.[UserId]
	JOIN @tblRequestDetail		rd		ON er.[RequestDetailId]	= rd.[RequestDetailId]
	JOIN @tblStudioType		st		ON st.[StudioTypeId]	= rd.[StudioTypeId]
	JOIN @tblParameters		pr		ON pr.[ParameterId]		= st.[ParameterId]
	JOIN @tblCodeMap		cm		ON cm.[CodeMapId]		= pr.[CodeMapId]
	JOIN @tblSample			sm		ON pr.[SampleId]		= sm.[SampleId]
	WHERE er.[RequestNo]	= @requestNo
		AND er.[branchCode]	= @branchCode
		AND sm.[Barcode]	= @barcode
		AND cm.[System] 	= @system
		--AND er.[RequestDate] = convert(DATE,GETDATE(),23)
GROUP BY us.[UserName], cm.[SystemSample], cm.[Code]
GO

EXEC sp_GetUsertData @userRequest = '10265012', @system = 'DRL';
GO
