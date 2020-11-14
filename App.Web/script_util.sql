ALTER TABLE [dbo].[Acomodacao] DROP CONSTRAINT [FK_Acomodacao_AcomodacaoDetalhe_DetalheId]
GO
truncate table Acomodacao
go
truncate table AcomodacaoDetalhe
GO
ALTER TABLE [dbo].[Acomodacao]
    ADD CONSTRAINT [FK_Acomodacao_AcomodacaoDetalhe_DetalheId] FOREIGN KEY ([DetalheId]) REFERENCES [dbo].[AcomodacaoDetalhe] ([DetalheId]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[Usuarios] Drop CONSTRAINT [FK_Usuarios_Enderecos_EnderecoId]
GO
ALTER TABLE [dbo].[Hospedes] Drop CONSTRAINT [FK_Hospedes_Enderecos_EnderecoId]
GO
truncate table Usuarios
go
truncate table Enderecos
GO
ALTER TABLE [dbo].[Usuarios]
    ADD CONSTRAINT [FK_Usuarios_Enderecos_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [dbo].[Enderecos] ([EnderecoId]) ON DELETE CASCADE;
GO
ALTER TABLE [dbo].[Hospedes]
    ADD CONSTRAINT [FK_Hospedes_Enderecos_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [dbo].[Enderecos] ([EnderecoId]) ON DELETE CASCADE;




ALTER TABLE Acomodacao NOCHECK CONSTRAINT ALL 
GO
ALTER TABLE Usuarios NOCHECK CONSTRAINT ALL
GO
ALTER TABLE AcomodacaoDetalhe NOCHECK CONSTRAINT ALL 
GO
ALTER TABLE Enderecos NOCHECK CONSTRAINT ALL
GO
truncate table Acomodacao
go
truncate table AcomodacaoDetalhe
go
truncate table Usuarios
go
truncate table Enderecos