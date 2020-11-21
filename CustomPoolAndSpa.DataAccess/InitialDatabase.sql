﻿CREATE TABLE [dbo].[Address] (
    [Id] [int] NOT NULL IDENTITY,
    [Street1] [nvarchar](50),
    [Street3] [nvarchar](50),
    [City] [nvarchar](30),
    [State] [nvarchar](30),
    [ZipCode] [nvarchar](20),
    CONSTRAINT [PK_dbo.Address] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Customer] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](100) NOT NULL,
    [CellPhone] [nvarchar](50),
    [WorkPhone] [nvarchar](50),
    [MainPhone] [nvarchar](50),
    [HomePhone] [nvarchar](50),
    CONSTRAINT [PK_dbo.Customer] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Material] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](50) NOT NULL,
    [Description] [nvarchar](250),
    CONSTRAINT [PK_dbo.Material] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[MaterialUsed] (
    [Id] [int] NOT NULL IDENTITY,
    [MaterialId] [int] NOT NULL,
    [Quantity] [real] NOT NULL,
    [ServiceReport_Id] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MaterialUsed] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_MaterialId] ON [dbo].[MaterialUsed]([MaterialId])
CREATE INDEX [IX_ServiceReport_Id] ON [dbo].[MaterialUsed]([ServiceReport_Id])
CREATE TABLE [dbo].[ServiceReport] (
    [Id] [int] NOT NULL IDENTITY,
    [ServiceDate] [datetime] NOT NULL,
    [ServiceTime] [datetime] NOT NULL,
    [ServiceType_VacuumService] [bit] NOT NULL,
    [ServiceType_ChemicalCheck] [bit] NOT NULL,
    [ServiceType_SPAService] [bit] NOT NULL,
    [ServiceType_PolarisService] [bit] NOT NULL,
    [ServiceType_ServiceCall] [bit] NOT NULL,
    [ServiceType_Delivery] [bit] NOT NULL,
    [AdditionalTime] [time](7) NOT NULL,
    [ServiceAddress_Id] [int] NOT NULL,
    [ServiceAddress_Id1] [int],
    CONSTRAINT [PK_dbo.ServiceReport] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_ServiceAddress_Id] ON [dbo].[ServiceReport]([ServiceAddress_Id])
CREATE INDEX [IX_ServiceAddress_Id1] ON [dbo].[ServiceReport]([ServiceAddress_Id1])
CREATE TABLE [dbo].[PoolConditionReport] (
    [Id] [int] NOT NULL,
    [ChlorineResidual] [nvarchar](20),
    [FreeChlorine] [nvarchar](20),
    [PHLevel] [nvarchar](20),
    [TotalAlkalinity] [nvarchar](20),
    [Turbidity] [nvarchar](20),
    [CyanuricAcidLevel] [nvarchar](20),
    [Temperature] [real] NOT NULL,
    CONSTRAINT [PK_dbo.PoolConditionReport] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Id] ON [dbo].[PoolConditionReport]([Id])
CREATE TABLE [dbo].[Person] (
    [Id] [int] NOT NULL IDENTITY,
    [FirstName] [nvarchar](50),
    [MiddleName] [nvarchar](50),
    [LastName] [nvarchar](50),
    CONSTRAINT [PK_dbo.Person] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[ServiceAddress] (
    [Id] [int] NOT NULL IDENTITY,
    [Address_Id] [int] NOT NULL,
    [Customer_Id] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ServiceAddress] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Address_Id] ON [dbo].[ServiceAddress]([Address_Id])
CREATE INDEX [IX_Customer_Id] ON [dbo].[ServiceAddress]([Customer_Id])
ALTER TABLE [dbo].[MaterialUsed] ADD CONSTRAINT [FK_dbo.MaterialUsed_dbo.Material_MaterialId] FOREIGN KEY ([MaterialId]) REFERENCES [dbo].[Material] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[MaterialUsed] ADD CONSTRAINT [FK_dbo.MaterialUsed_dbo.ServiceReport_ServiceReport_Id] FOREIGN KEY ([ServiceReport_Id]) REFERENCES [dbo].[ServiceReport] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ServiceReport] ADD CONSTRAINT [FK_dbo.ServiceReport_dbo.Address_ServiceAddress_Id] FOREIGN KEY ([ServiceAddress_Id]) REFERENCES [dbo].[Address] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ServiceReport] ADD CONSTRAINT [FK_dbo.ServiceReport_dbo.ServiceAddress_ServiceAddress_Id1] FOREIGN KEY ([ServiceAddress_Id1]) REFERENCES [dbo].[ServiceAddress] ([Id])
ALTER TABLE [dbo].[PoolConditionReport] ADD CONSTRAINT [FK_dbo.PoolConditionReport_dbo.ServiceReport_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[ServiceReport] ([Id])
ALTER TABLE [dbo].[ServiceAddress] ADD CONSTRAINT [FK_dbo.ServiceAddress_dbo.Address_Address_Id] FOREIGN KEY ([Address_Id]) REFERENCES [dbo].[Address] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ServiceAddress] ADD CONSTRAINT [FK_dbo.ServiceAddress_dbo.Customer_Customer_Id] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customer] ([Id]) ON DELETE CASCADE
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201904042104134_InitialDatabase', N'CustomPoolAndSpa.DataAccess.Migrations.Configuration',  0x1F8B0800000000000400ED5DDB6EE4B8117D0F907F10FA319875FB824512A3BD0B6F7B266B643C76A66727415E0C5AA2DBC4E8D29128C346B05FB60FF9A4FC42485D791729B1DB3DCE6081595B224F158BC55215C92AFFF7B7FF2C7E7C4AE2E011E605CAD2B3D9D1C1E12C80699845285D9FCD4A7CFFDD9F663FFEF0FBDF2DDE46C953F0B96D7742DB919E6971367BC078733A9F17E1034C407190A030CF8AEC1E1F8459320751363F3E3CFCF3FCE8680E09C48C6005C1E263996294C0EA17F2EB324B43B8C12588AFB208C645F39CBC5955A8C10790C062034278365B9605CE929B2C8BCFD368B50107170083F3308445310BCE6304084B2B18DFCF0290A6190698307CFA4B015738CFD235E98011883F3D6F2069770FE202360339ED9BDB8EE9F0988E69DE776CA1C28A4747C0A393464873B1FB2851CF3A2156024E36317CA2C3AE644945943FA210D227B3402478BA8C73FA46256DD20EA5074CF73781A6D19B4E5F885AD1FF68CB1897393C4B61897310BF096ECABB18857F85CF9FB22F303D4BCB38661927ACDFE4D906E6F8B9E1FB3308CB3269C8CF829ACB9F086908889C3E90FEE02E86DDD4CE8D604B2247148298FC3FFC32156C7573EE89AD9B2C06392A3CA135304B40443B11EA02C688D88A67379CC59C513FF6F95B6204F033A394E7519457EBD8A09059926469AB864D07A258EC633F8A47DE710F18717C84F70DC7979124B3B9D8519422ED530FE632C527C70AE931035FE12C877F8129CC0186D10DC018E629C58095F006271FE710E2A39620F99518F65970059EDEC3748D1FCE66DF134BFE0E3DC1A87DD0F0F04B8AC86780F4C17939AC631599936D93595623D6D238F1331422E86D13F927DA2C496303996377328B79BFA08CCBACB6D7301F63F8DBBE5BB6FAAF62F1D17F0D537C746837C7AE1F3518C7370F596A22ED6535FE3DCBBFEC84D01551AB9D10FA9968F61608592FCC2BA26639714FC72CCCB6EFB7853979615A4EB1B3F3548439DAD40EBDDEEEEF42BF4838144DD131DAFF9B9E0DEB592BAF619A669CBF95A0A1D7E80DD19AD842033F8047B4AE46A2616C167C8471D5A078409B3A70E666F9B66FF92ECF928F592CA851D7E07695957915AD64A6569F40BE86D89ED3267AF90837598E87D9159A6B78E65A9919E79BAAB8B75E7D026FA383EE1AE0DBFAB3887E6A815D301E3DFDF9134ADCCD77BBE381127F58D5E64BB3A4A92A73CF1D3149288CA8CC40CCB268C79E76F551E55A66698DAC5C7D5C8B7641E916E160E36E81B56B71B847BB7A1D0D4AB7D5A018934040E8D00FC7D44EB22AC6C693EC8A424663AC8B02E6F5DA98A17DC138239E1999AC02452588FDC6E932BD7739842DCD6DD3BAF9F93D7C845B1FD227A277F179FC05C42835EFDAF82157E67728DA01A1E53348CB1C85E7218A762348986CE8E78FAC2D6FEEDFB053E5D9AC8BC6D0FE4330CE2212E344BF57B6DBC875FB6FBBC85AFB84F202FB099A070226144531DC05A5F7601B23728D056C0E3CCCC1407F02F24ABFD413B4586BFF2C9CBFD633D3BB7D420B9DC32736730D80FBCDFA6166FBB65A6EDB2643EC76ED2605EC5622167B6879E71B0E8D4068EDF241392F8A2C4415DB8A9DB37E4F8417C9DB340AAC3648FA808FDF90BB220B136DC852242C9DCDFE20C97C8840173CC90444F0A399B89EAFD30B18430C83F3B0BEB2B004450822D990129945FC136202604ED720A01FF58218159462D95EA034441B10DB0C41E86C696E28731D19F1CD05DCC0945A0A9B39B2A1CF6EEEC97C74E404E10DC96A316794CFAC93C33E9A4E7D1C1CB65E95946126AF558707074706AD7508FFA53D11354199DA285DB4666C077A693D37E379D9816E1AB75074FA61B79F62A91A26F369B517C310EA9C806D195107C91AB6BBADBE1683EBDCCB3769EAB27E01C16A1CBF011DD27A81D250354A64A1A73A17724F3554E7945A8E52F650B7204AC9BD6588F45EF4FE0953F0952D47AB739C6D053BF05DB773BC471A6EADAC6AD79D7CA830F94CC19C0B97FA30F8E28EB6804FAA2D7162A99A30BB688279718494C20A623E6C5CD1D1F48183B8022531F120AD76A9517ADD1B8069ADAD1AA677FB2D61A8D13643D59F8301386E62D578C2DC0F002ABC2135ACD23B1D02AFB6FD3478CD16A2DD808D9A21AE2D0192516FF5BC3067F04C5BE361BD68A86C43D36E780ACD90FC48DB705401AA00E4D639796F21248B4D6A59608E51D3C8B88919B34E850DF2B40F94183AF2DA9B2C60F341A82C5B7BAFDFDDEF7718A9BBAFCF80B34B79B2004D775306D6B2AD4E5A38F73E56F50BAA9FB415AB553CA3EFEEE2BDCBE3D2AB858BC7BE2D3DD3EE030F8A4AED9D3BF9E7BE8425F9E40C30E735F91697B8013D283493173EC20FF725408DE3ED6791B67BE59DC3DDBD5BCCEB2CBDE6014DF751A6F32DAEC06683D23593DED73C09564D6EDF772BF75CB7A4C69887DC4488E141470967395843E12D3D108E6075CC49D309EF003D795A4689DC4C1B5E68FCC496AE1441C8B3DABA8D6D17FAB33AA861721E0F34B6AE17EE3B32DE84EE2F56C767B205927B0634EF12C420571CD62DB3B84C52FDEEA2BE77978AC442740F5D714E5438272E387532110BB2541C229A39A92E16F27C548FEC31BA4C2016A57B28E32CE6C2B44ABBBB9222495B11BC6A5A292E6B7F7D69AEEED363A1BAFAAEDBD1DDFAA600DBBF7EE2A06D7D560EA772FD637B2C26F186C5621EDB6331B9352C16F3D81E8B499F61B198C77BA3CF6C20EA4B9F75D1B7853EEBBBEEAB3E73D92C2C10F762EFE6BB8D7B7CCF79B53B367EDED5DDB733F7ECB935BFE4F5E7D97AB43E3585C5EA9FEE8D0648AEAF2F153006EA163A30D07F4BCE189B19C13930EC0B67BC3ADD408157BF50E235C501865224AC27A2EAA220A4635DA828A1629E20DE0ACD5443D17EFBF932133A0A4233170A6CED091D3CDBC6055BAC46A1C317DB39F15F77AA6B546807C0367241EFCB56E8A0FB164A159D0B3A6ABD2CC4A41C96BEF86E6F2CA566C3DA97BD549DD4B85B4D2B94EDD84E393B84F3E8A5B7F6C87C1E088BCABFB147ECB23D58B0EEA13D8E94CEC1E2492F1D70FBBC0D0EB17FEC302F726A063731F26B073ED92C0C8E53F6C5FE2CE1EE64D3DBAAADCF43472C544DC7EDAC4D2653815B3EFD630747994946E01C65E6B93D5A9F70C062F54FF74677E42D68CF9EF2F81DCB2180693AB56D79F35BEB86E8443A691D118848184E61073D6330DDEBD79CA3CA22B59A0E014C7D6995E16822B3DAFBB3A37547CF9D78A0E2AC18A61364F72D0A11C1653F4221E6E113E2691AD160795088E153F2AF431D7447E2630CF0ED906D301CA31B93EAC563EF91A2F56F0F34C7FD5FE5D4F767FCA3E6BEEFEE7BF2C563FC91D2ED60FC4FBF7883E1AB9C7FF1D2C2282D10413C3909E6FB0EBEBC04C5A9F134BD50DF9FD8897654FBA0CD6E467059D02CD82E03D64D08C37A26DDE4109B748E70F3A4FBBDBBC9D1DCA2B0A8D62C5EABA89BCC0222854714D12B15ABE702C3A452D283D5BFE2658C88EBDD37B80229BA8705AE739367C78747C7429DE7FDA9B93C2F8A883BC3D397B8E5E76C07F9D5286DFD3D5306B56B2123BEBC6CFA08F2F001E4521A7D0F3BA29AAC2754B678AC12F26404A34C65294F9842695825EAF100AA7B25D8D7A18EF54E8A417055C9D5A9F5543DE9A3543ED513AE542DD513AE541C7514AE7B2DD4FF13D5FCDE5D33151545D5E6C2FBA4C8FB035FEDC4C8353A2B3252B2D8651AC1A7B3D9BFAB6EA7C1E53F6EFB9E6F82EB9CB82AA7C161F0EBE4E29E39A48746E32A0A321B266E6311FB3B8C6864FDCBD7A13DDC75899A4E447EC69E2A4C4EC652DC5CA891EF109E04AAFCD3195341E53FA1311551FDA73426F3C9DE44F00329FE698D3178EA12A0B5FEDCE43044F51FEFF9E35846D90DB951E6A5079864315541F0447E8E740C4DF8580E5E51D899D5B390C8C429D155CC1C15BEC8F0AA02999EA0857A989E5035E52F7DA18BD52E3DE16A8B5BFAE25BAE6569E1EDB8967D7C1D9E855473D15778289558F4042C5654DC6E78683AA5F86AE77CFC07D6D397953B7471E380E9EA2178F055816FF7C5F0D4F9D3132A2C4DAAAEB7EB4A7AAFBD729EE206C6B83A75C6620F5EEAEE8DD29BA16406EFCA63771BD896ECBE56B6E3EE69ECAA64970FC5F5648EF457FEBC2B94BB065B5D3FDB81668DA8EC37DA1CBDBA0FDECE0D97F357CFE64EDBEEEC976D99C3BDB15C2A46C457AFC476B9507C71AB65554F86994EFEDEDACE4A2EEE954A192A1FEC834E0D5CBDDBBD5299EAEDF89856BBFA962FE43B8D98C09777A19477F3BC2B8E708FAD555FA9948F38B1CAB29EA69A9EF5ADB5B359749791F9AF77335C0B7E1AAB7DAA0838D702351602555118552674B046A889927B15D1E112A22A7A42930182CA105B22AB6CA5223EBE16A9A110A992D09822A516154A0D12DDAF2AA6CADA860AD3A38B5174A92F03776A2D86BEF3DAA4CA45A3B8C46D128E611D6893AEA78BCA9CB7E6ADCAA8A0FE5C09349350460A763FAB85FAD0925D2D215DB69287F29F137541D57DC03EEE594D4FD129E1ABAAEDA908C46C956DD5E97418D4962D8543D14D39258338D6654A6FFFD4BF5DC002AD7B089A6F92C29073A9BB3697E97DD67AF902476D13F158196210D13CA31CA37B1062F29A261C557F53EF33884BD2E46D7207A3CBF4BAC49B129321C3E42EE60A3CD008C144BFAA2CCAF3BCB8AEAEBF163E8640D844F4C2DD75FA5389E2A8E3FB9DE2D8520341438FE63C98CE25A6E7C2EBE70EE98354044F07D488AF8B98E8CD89988015D7E90A3CC231BC11ABFC1EAE41F8DC66D6E84186278217FBE20281750E92A2C1E8FB935F890E47C9D30FFF03DAD6910A6D8E0000 , N'6.2.0-61023')

