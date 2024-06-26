USE [aluguer_equipamentos]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 14/05/2024 16:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[id_administrador] [int] IDENTITY(1,1) NOT NULL,
	[cc] [int] NOT NULL,
	[nome] [nvarchar](255) NULL,
	[email] [nvarchar](255) NOT NULL,
	[telefone] [varchar](20) NULL,
	[pass] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_administrador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[telefone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[cc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvaliacaoFeedback]    Script Date: 14/05/2024 16:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvaliacaoFeedback](
	[id_feedback] [int] IDENTITY(1,1) NOT NULL,
	[comentario] [nvarchar](255) NULL,
	[classificacao] [smallint] NULL,
	[data_avaliacao] [datetime] NULL,
	[id_utilizador] [int] NULL,
	[id_reserva] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_feedback] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipamento]    Script Date: 14/05/2024 16:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipamento](
	[id_equipamento] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](255) NULL,
	[categoria] [nvarchar](255) NULL,
	[disponivel] [bit] NULL,
	[id_localizacao] [int] NULL,
	[id_fornecedor] [int] NULL,
	[id_administrador] [int] NULL,
	[revisao] [date] NULL,
	[preco] [int] NULL,
	[id_tecnico] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_equipamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipamentoAudit]    Script Date: 14/05/2024 16:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipamentoAudit](
	[audit_id] [int] IDENTITY(1,1) NOT NULL,
	[id_equipamento] [int] NULL,
	[nome] [nvarchar](50) NULL,
	[categoria] [nvarchar](50) NULL,
	[operation] [nvarchar](10) NULL,
	[operation_date] [datetime] NULL,
	[deleted_id] [int] NULL,
	[deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[audit_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fornecedor]    Script Date: 14/05/2024 16:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fornecedor](
	[id_fornecedor] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](255) NULL,
	[email] [nvarchar](255) NOT NULL,
	[telefone] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_fornecedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[telefone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistoricoAluguer]    Script Date: 14/05/2024 16:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoricoAluguer](
	[id_historico] [int] IDENTITY(1,1) NOT NULL,
	[data_aluguer] [datetime] NULL,
	[id_equipamento] [int] NULL,
	[id_reserva] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_historico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localizacao]    Script Date: 14/05/2024 16:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localizacao](
	[id_localizacao] [int] IDENTITY(1,1) NOT NULL,
	[endereco] [nvarchar](255) NULL,
	[cidade] [nvarchar](255) NULL,
	[pais] [nvarchar](255) NULL,
	[id_administrador] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_localizacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManutencaoEquipamento]    Script Date: 14/05/2024 16:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManutencaoEquipamento](
	[id_manutencao] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [nvarchar](max) NULL,
	[id_equipamento] [int] NULL,
	[id_tecnico] [int] NULL,
	[data] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_manutencao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 14/05/2024 16:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[id_reserva] [int] IDENTITY(1,1) NOT NULL,
	[data_inicio] [datetime] NULL,
	[data_fim] [datetime] NULL,
	[duracao_aluguer] [int] NULL,
	[id_utilizador] [int] NULL,
	[id_equipamento] [int] NULL,
	[desconto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeguroEquipamento]    Script Date: 14/05/2024 16:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeguroEquipamento](
	[id_seguro] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [nvarchar](max) NULL,
	[id_equipamento] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_seguro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TecnicoManutencao]    Script Date: 14/05/2024 16:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TecnicoManutencao](
	[id_tecnico] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](255) NULL,
	[telefone] [varchar](20) NULL,
	[email] [nvarchar](255) NOT NULL,
	[password] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tecnico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[telefone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transacao]    Script Date: 14/05/2024 16:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transacao](
	[id_transacao] [int] IDENTITY(1,1) NOT NULL,
	[valor] [decimal](10, 2) NULL,
	[MetodoPagamento] [nvarchar](255) NULL,
	[id_reserva] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_transacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilizador]    Script Date: 14/05/2024 16:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilizador](
	[id_utilizador] [int] IDENTITY(1,1) NOT NULL,
	[cc] [int] NOT NULL,
	[nome] [nvarchar](255) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[telefone] [varchar](20) NULL,
	[endereco] [nvarchar](255) NULL,
	[data_nascimento] [date] NOT NULL,
	[pass] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_utilizador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[telefone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[cc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Reserva] ADD  DEFAULT ((0)) FOR [desconto]
GO
ALTER TABLE [dbo].[AvaliacaoFeedback]  WITH CHECK ADD FOREIGN KEY([id_reserva])
REFERENCES [dbo].[Reserva] ([id_reserva])
GO
ALTER TABLE [dbo].[AvaliacaoFeedback]  WITH CHECK ADD FOREIGN KEY([id_utilizador])
REFERENCES [dbo].[Utilizador] ([id_utilizador])
GO
ALTER TABLE [dbo].[Equipamento]  WITH CHECK ADD FOREIGN KEY([id_administrador])
REFERENCES [dbo].[Administrador] ([id_administrador])
GO
ALTER TABLE [dbo].[Equipamento]  WITH CHECK ADD FOREIGN KEY([id_fornecedor])
REFERENCES [dbo].[Fornecedor] ([id_fornecedor])
GO
ALTER TABLE [dbo].[Equipamento]  WITH CHECK ADD FOREIGN KEY([id_localizacao])
REFERENCES [dbo].[Localizacao] ([id_localizacao])
GO
ALTER TABLE [dbo].[Equipamento]  WITH CHECK ADD  CONSTRAINT [fk_id_tecnico] FOREIGN KEY([id_tecnico])
REFERENCES [dbo].[TecnicoManutencao] ([id_tecnico])
GO
ALTER TABLE [dbo].[Equipamento] CHECK CONSTRAINT [fk_id_tecnico]
GO
ALTER TABLE [dbo].[HistoricoAluguer]  WITH CHECK ADD  CONSTRAINT [FK__Historico__id_eq__440B1D61] FOREIGN KEY([id_equipamento])
REFERENCES [dbo].[Equipamento] ([id_equipamento])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HistoricoAluguer] CHECK CONSTRAINT [FK__Historico__id_eq__440B1D61]
GO
ALTER TABLE [dbo].[HistoricoAluguer]  WITH CHECK ADD  CONSTRAINT [FK_Historico_id_re_44F4F419A] FOREIGN KEY([id_reserva])
REFERENCES [dbo].[Reserva] ([id_reserva])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HistoricoAluguer] CHECK CONSTRAINT [FK_Historico_id_re_44F4F419A]
GO
ALTER TABLE [dbo].[Localizacao]  WITH CHECK ADD FOREIGN KEY([id_administrador])
REFERENCES [dbo].[Administrador] ([id_administrador])
GO
ALTER TABLE [dbo].[ManutencaoEquipamento]  WITH CHECK ADD FOREIGN KEY([id_equipamento])
REFERENCES [dbo].[Equipamento] ([id_equipamento])
GO
ALTER TABLE [dbo].[ManutencaoEquipamento]  WITH CHECK ADD FOREIGN KEY([id_tecnico])
REFERENCES [dbo].[TecnicoManutencao] ([id_tecnico])
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD FOREIGN KEY([id_equipamento])
REFERENCES [dbo].[Equipamento] ([id_equipamento])
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD FOREIGN KEY([id_utilizador])
REFERENCES [dbo].[Utilizador] ([id_utilizador])
GO
ALTER TABLE [dbo].[SeguroEquipamento]  WITH CHECK ADD FOREIGN KEY([id_equipamento])
REFERENCES [dbo].[Equipamento] ([id_equipamento])
GO
ALTER TABLE [dbo].[Transacao]  WITH CHECK ADD  CONSTRAINT [FK_Transacao_id_re] FOREIGN KEY([id_reserva])
REFERENCES [dbo].[Reserva] ([id_reserva])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transacao] CHECK CONSTRAINT [FK_Transacao_id_re]
GO
