
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/29/2023 17:39:40
-- Generated from EDMX file: C:\Users\PC\Desktop\Gestion_Emploi\GestionEmploi\GestionEmploi\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Gestion_Emploi];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Formateurs'
CREATE TABLE [dbo].[Formateurs] (
    [IdFormateur] int IDENTITY(1,1) NOT NULL,
    [NomFormateur] nvarchar(max)  NOT NULL,
    [Groupe_idGroupe] int  NOT NULL
);
GO

-- Creating table 'Groupes'
CREATE TABLE [dbo].[Groupes] (
    [idGroupe] int IDENTITY(1,1) NOT NULL,
    [NomGroupe] nvarchar(max)  NOT NULL,
    [Filiere_idFiliere] int  NOT NULL
);
GO

-- Creating table 'Filieres'
CREATE TABLE [dbo].[Filieres] (
    [idFiliere] int IDENTITY(1,1) NOT NULL,
    [NomFiliere] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'emploies'
CREATE TABLE [dbo].[emploies] (
    [idEmploie] int IDENTITY(1,1) NOT NULL,
    [Jours] datetime  NOT NULL,
    [heure_debut] time  NOT NULL,
    [heure_fin] time  NOT NULL,
    [FormateurIdFormateur] int  NOT NULL,
    [Groupe_idGroupe] int  NOT NULL,
    [Module_idModule] int  NOT NULL
);
GO

-- Creating table 'Modules'
CREATE TABLE [dbo].[Modules] (
    [idModule] int IDENTITY(1,1) NOT NULL,
    [NomModule] nvarchar(max)  NOT NULL,
    [DureeModule] nvarchar(max)  NOT NULL,
    [FormateurIdFormateur] int  NOT NULL,
    [Salle_idSalle] int  NOT NULL
);
GO

-- Creating table 'Salles'
CREATE TABLE [dbo].[Salles] (
    [idSalle] int IDENTITY(1,1) NOT NULL,
    [NomSalle] nvarchar(max)  NOT NULL,
    [FormateurIdFormateur] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdFormateur] in table 'Formateurs'
ALTER TABLE [dbo].[Formateurs]
ADD CONSTRAINT [PK_Formateurs]
    PRIMARY KEY CLUSTERED ([IdFormateur] ASC);
GO

-- Creating primary key on [idGroupe] in table 'Groupes'
ALTER TABLE [dbo].[Groupes]
ADD CONSTRAINT [PK_Groupes]
    PRIMARY KEY CLUSTERED ([idGroupe] ASC);
GO

-- Creating primary key on [idFiliere] in table 'Filieres'
ALTER TABLE [dbo].[Filieres]
ADD CONSTRAINT [PK_Filieres]
    PRIMARY KEY CLUSTERED ([idFiliere] ASC);
GO

-- Creating primary key on [idEmploie] in table 'emploies'
ALTER TABLE [dbo].[emploies]
ADD CONSTRAINT [PK_emploies]
    PRIMARY KEY CLUSTERED ([idEmploie] ASC);
GO

-- Creating primary key on [idModule] in table 'Modules'
ALTER TABLE [dbo].[Modules]
ADD CONSTRAINT [PK_Modules]
    PRIMARY KEY CLUSTERED ([idModule] ASC);
GO

-- Creating primary key on [idSalle] in table 'Salles'
ALTER TABLE [dbo].[Salles]
ADD CONSTRAINT [PK_Salles]
    PRIMARY KEY CLUSTERED ([idSalle] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FormateurIdFormateur] in table 'Modules'
ALTER TABLE [dbo].[Modules]
ADD CONSTRAINT [FK_Enseigner]
    FOREIGN KEY ([FormateurIdFormateur])
    REFERENCES [dbo].[Formateurs]
        ([IdFormateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Enseigner'
CREATE INDEX [IX_FK_Enseigner]
ON [dbo].[Modules]
    ([FormateurIdFormateur]);
GO

-- Creating foreign key on [Salle_idSalle] in table 'Modules'
ALTER TABLE [dbo].[Modules]
ADD CONSTRAINT [FK_Etudier]
    FOREIGN KEY ([Salle_idSalle])
    REFERENCES [dbo].[Salles]
        ([idSalle])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Etudier'
CREATE INDEX [IX_FK_Etudier]
ON [dbo].[Modules]
    ([Salle_idSalle]);
GO

-- Creating foreign key on [FormateurIdFormateur] in table 'Salles'
ALTER TABLE [dbo].[Salles]
ADD CONSTRAINT [FK_Lier]
    FOREIGN KEY ([FormateurIdFormateur])
    REFERENCES [dbo].[Formateurs]
        ([IdFormateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Lier'
CREATE INDEX [IX_FK_Lier]
ON [dbo].[Salles]
    ([FormateurIdFormateur]);
GO

-- Creating foreign key on [Filiere_idFiliere] in table 'Groupes'
ALTER TABLE [dbo].[Groupes]
ADD CONSTRAINT [FK_Appartient]
    FOREIGN KEY ([Filiere_idFiliere])
    REFERENCES [dbo].[Filieres]
        ([idFiliere])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Appartient'
CREATE INDEX [IX_FK_Appartient]
ON [dbo].[Groupes]
    ([Filiere_idFiliere]);
GO

-- Creating foreign key on [FormateurIdFormateur] in table 'emploies'
ALTER TABLE [dbo].[emploies]
ADD CONSTRAINT [FK_Avoir]
    FOREIGN KEY ([FormateurIdFormateur])
    REFERENCES [dbo].[Formateurs]
        ([IdFormateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Avoir'
CREATE INDEX [IX_FK_Avoir]
ON [dbo].[emploies]
    ([FormateurIdFormateur]);
GO

-- Creating foreign key on [Groupe_idGroupe] in table 'Formateurs'
ALTER TABLE [dbo].[Formateurs]
ADD CONSTRAINT [FK_Integrer]
    FOREIGN KEY ([Groupe_idGroupe])
    REFERENCES [dbo].[Groupes]
        ([idGroupe])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Integrer'
CREATE INDEX [IX_FK_Integrer]
ON [dbo].[Formateurs]
    ([Groupe_idGroupe]);
GO

-- Creating foreign key on [Groupe_idGroupe] in table 'emploies'
ALTER TABLE [dbo].[emploies]
ADD CONSTRAINT [FK_Associer]
    FOREIGN KEY ([Groupe_idGroupe])
    REFERENCES [dbo].[Groupes]
        ([idGroupe])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Associer'
CREATE INDEX [IX_FK_Associer]
ON [dbo].[emploies]
    ([Groupe_idGroupe]);
GO

-- Creating foreign key on [Module_idModule] in table 'emploies'
ALTER TABLE [dbo].[emploies]
ADD CONSTRAINT [FK_Attacher]
    FOREIGN KEY ([Module_idModule])
    REFERENCES [dbo].[Modules]
        ([idModule])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Attacher'
CREATE INDEX [IX_FK_Attacher]
ON [dbo].[emploies]
    ([Module_idModule]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------