
CREATE TABLE [dbo].[LogDetails] (  
[LogID] int NOT NULL IDENTITY(1,1) ,  
[LogDate] datetime NOT NULL ,  
[LogThread] nvarchar(100) NOT NULL ,  
[LogLevel] nvarchar(200) NOT NULL ,  
[LogLogger] nvarchar(500) NOT NULL ,  
[LogMessage] nvarchar(3000) NOT NULL ,  
[LogActionClick] nvarchar(4000) NULL ,  
[UserName] nvarchar(30) NULL ,  
[UserIP] varchar(20) NULL   
)