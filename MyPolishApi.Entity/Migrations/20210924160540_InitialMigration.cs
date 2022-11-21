using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPolishApi.Entity.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DictionaryItem",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryItem", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "NameAddress",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.Login);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    BicOrSwift = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAddressId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.BicOrSwift);
                    table.ForeignKey(
                        name: "FK_Bank_NameAddress_NameAddressId",
                        column: x => x.NameAddressId,
                        principalTable: "NameAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountInfo",
                columns: table => new
                {
                    BicOrSwift = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameAddressId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountInfo", x => x.BicOrSwift);
                    table.ForeignKey(
                        name: "FK_BankAccountInfo_NameAddress_NameAddressId",
                        column: x => x.NameAddressId,
                        principalTable: "NameAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SenderRecipient",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountMassPayment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BicOrSwift = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NameAddressId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenderRecipient", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_SenderRecipient_Bank_BicOrSwift",
                        column: x => x.BicOrSwift,
                        principalTable: "Bank",
                        principalColumn: "BicOrSwift",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SenderRecipient_NameAddress_NameAddressId",
                        column: x => x.NameAddressId,
                        principalTable: "NameAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountInfo",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameAddressId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccountType = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccountHolderType = table.Column<int>(type: "int", nullable: false),
                    AccountTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNameClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BicOrSwift = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VatAccountNrb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInfo", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_AccountInfo_BankAccountInfo_BicOrSwift",
                        column: x => x.BicOrSwift,
                        principalTable: "BankAccountInfo",
                        principalColumn: "BicOrSwift",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountInfo_DictionaryItem_AccountType",
                        column: x => x.AccountType,
                        principalTable: "DictionaryItem",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountInfo_NameAddress_NameAddressId",
                        column: x => x.NameAddressId,
                        principalTable: "NameAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCancelledInfo",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionCategory = table.Column<int>(type: "int", nullable: false),
                    TransactionStatus = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Initiator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecipientId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCancelledInfo", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_TransactionCancelledInfo_DictionaryItem_TransactionStatus",
                        column: x => x.TransactionStatus,
                        principalTable: "DictionaryItem",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionCancelledInfo_NameAddress_Initiator",
                        column: x => x.Initiator,
                        principalTable: "NameAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionCancelledInfo_SenderRecipient_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "SenderRecipient",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionCancelledInfo_SenderRecipient_SenderId",
                        column: x => x.SenderId,
                        principalTable: "SenderRecipient",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionInfo",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionCategory = table.Column<int>(type: "int", nullable: false),
                    TransactionStatus = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Initiator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecipientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostTransactionBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionInfo", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_TransactionInfo_DictionaryItem_TransactionStatus",
                        column: x => x.TransactionStatus,
                        principalTable: "DictionaryItem",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionInfo_NameAddress_Initiator",
                        column: x => x.Initiator,
                        principalTable: "NameAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionInfo_SenderRecipient_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "SenderRecipient",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionInfo_SenderRecipient_SenderId",
                        column: x => x.SenderId,
                        principalTable: "SenderRecipient",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionPendingInfo",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionCategory = table.Column<int>(type: "int", nullable: false),
                    Initiator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecipientId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionPendingInfo", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_TransactionPendingInfo_NameAddress_Initiator",
                        column: x => x.Initiator,
                        principalTable: "NameAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionPendingInfo_SenderRecipient_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "SenderRecipient",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionPendingInfo_SenderRecipient_SenderId",
                        column: x => x.SenderId,
                        principalTable: "SenderRecipient",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionRejectedInfo",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionCategory = table.Column<int>(type: "int", nullable: false),
                    Initiator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecipientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RejectionDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRejectedInfo", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_TransactionRejectedInfo_NameAddress_Initiator",
                        column: x => x.Initiator,
                        principalTable: "NameAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionRejectedInfo_SenderRecipient_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "SenderRecipient",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionRejectedInfo_SenderRecipient_SenderId",
                        column: x => x.SenderId,
                        principalTable: "SenderRecipient",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionScheduledInfo",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionCategory = table.Column<int>(type: "int", nullable: false),
                    TransactionStatus = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Initiator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecipientId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionScheduledInfo", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_TransactionScheduledInfo_DictionaryItem_TransactionStatus",
                        column: x => x.TransactionStatus,
                        principalTable: "DictionaryItem",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionScheduledInfo_NameAddress_Initiator",
                        column: x => x.Initiator,
                        principalTable: "NameAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionScheduledInfo_SenderRecipient_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "SenderRecipient",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionScheduledInfo_SenderRecipient_SenderId",
                        column: x => x.SenderId,
                        principalTable: "SenderRecipient",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountPsuRelation",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeOfRelation = table.Column<int>(type: "int", nullable: false),
                    TypeOfProxy = table.Column<int>(type: "int", nullable: true),
                    Stake = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPsuRelation", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_AccountPsuRelation_AccountInfo_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "AccountInfo",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkedAccount",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LinkedAccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedAccount", x => new { x.AccountNumber, x.LinkedAccountNumber });
                    table.ForeignKey(
                        name: "FK_LinkedAccount_AccountInfo_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "AccountInfo",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountInfo_AccountType",
                table: "AccountInfo",
                column: "AccountType",
                filter: "[AccountType] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AccountInfo_BicOrSwift",
                table: "AccountInfo",
                column: "BicOrSwift",
                filter: "[BicOrSwift] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AccountInfo_NameAddressId",
                table: "AccountInfo",
                column: "NameAddressId",
                filter: "[NameAddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_NameAddressId",
                table: "Bank",
                column: "NameAddressId",
                filter: "[NameAddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountInfo_NameAddressId",
                table: "BankAccountInfo",
                column: "NameAddressId",
                filter: "[NameAddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedAccount_AccountNumber",
                table: "LinkedAccount",
                column: "AccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SenderRecipient_BicOrSwift",
                table: "SenderRecipient",
                column: "BicOrSwift",
                filter: "[BicOrSwift] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SenderRecipient_NameAddressId",
                table: "SenderRecipient",
                column: "NameAddressId",
                filter: "[NameAddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCancelledInfo_Initiator",
                table: "TransactionCancelledInfo",
                column: "Initiator",
                filter: "[Initiator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCancelledInfo_RecipientId",
                table: "TransactionCancelledInfo",
                column: "RecipientId",
                filter: "[RecipientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCancelledInfo_SenderId",
                table: "TransactionCancelledInfo",
                column: "SenderId",
                filter: "[SenderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCancelledInfo_TransactionStatus",
                table: "TransactionCancelledInfo",
                column: "TransactionStatus",
                filter: "[TransactionStatus] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionInfo_Initiator",
                table: "TransactionInfo",
                column: "Initiator",
                filter: "[Initiator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionInfo_RecipientId",
                table: "TransactionInfo",
                column: "RecipientId",
                filter: "[RecipientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionInfo_SenderId",
                table: "TransactionInfo",
                column: "SenderId",
                filter: "[SenderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionInfo_TransactionStatus",
                table: "TransactionInfo",
                column: "TransactionStatus",
                filter: "[TransactionStatus] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionPendingInfo_Initiator",
                table: "TransactionPendingInfo",
                column: "Initiator",
                filter: "[Initiator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionPendingInfo_RecipientId",
                table: "TransactionPendingInfo",
                column: "RecipientId",
                filter: "[RecipientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionPendingInfo_SenderId",
                table: "TransactionPendingInfo",
                column: "SenderId",
                filter: "[SenderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRejectedInfo_Initiator",
                table: "TransactionRejectedInfo",
                column: "Initiator",
                filter: "[Initiator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRejectedInfo_RecipientId",
                table: "TransactionRejectedInfo",
                column: "RecipientId",
                filter: "[RecipientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRejectedInfo_SenderId",
                table: "TransactionRejectedInfo",
                column: "SenderId",
                filter: "[SenderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionScheduledInfo_Initiator",
                table: "TransactionScheduledInfo",
                column: "Initiator",
                filter: "[Initiator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionScheduledInfo_RecipientId",
                table: "TransactionScheduledInfo",
                column: "RecipientId",
                filter: "[RecipientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionScheduledInfo_SenderId",
                table: "TransactionScheduledInfo",
                column: "SenderId",
                filter: "[SenderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionScheduledInfo_TransactionStatus",
                table: "TransactionScheduledInfo",
                column: "TransactionStatus",
                filter: "[TransactionStatus] IS NOT NULL");
				
				
			migrationBuilder.Sql(@" 
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'1', N'Mickiewicza 16, 90-001 Łódź');
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'2', N'Piłsudskiego 34a, 90-123 Warszawa');
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'3', N'Wojska Polskiego 102, 91-002 Łódź');
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'4', N'Sienkiewicza 15/34, 96-230 Łódź');
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'5', N'Iglasta 37, 97-115 Bielsko-Biała');
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'6', N'Dąbrowskiego 8, 93-345 Pabianice');
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'7', N'Kabadzka 16');
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'8', N'Tramwajowa 66');
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'9', N'Katarska 17');
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'10', N'Bliska 89');
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'11', N'Zielona 33');
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'12', N'Pomorska 77');
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'13', N'Pomidorowa 15');
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'14', N'Napoleona 99');
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'15', N'Wielbłądzia 9');
                                    INSERT [dbo].[NameAddress] ([Id], [Value]) VALUES (N'16', N'Kolorowa 53');

                                    INSERT [dbo].[DictionaryItem] ([Code], [Description]) VALUES (N'1', N'KONTO Direct');
                                    INSERT [dbo].[DictionaryItem] ([Code], [Description]) VALUES (N'2', N'Done');
                                    INSERT [dbo].[DictionaryItem] ([Code], [Description]) VALUES (N'3', N'Pending');
                                    INSERT [dbo].[DictionaryItem] ([Code], [Description]) VALUES (N'4', N'Canceled');
                                    INSERT [dbo].[DictionaryItem] ([Code], [Description]) VALUES (N'5', N'Rejected');
                                    INSERT [dbo].[DictionaryItem] ([Code], [Description]) VALUES (N'6', N'Scheduled');

                                    INSERT [dbo].[Bank] ([BicOrSwift], [Name], [Code], [CountryCode], [NameAddressId]) VALUES (N'INGBPLPW', N'ING Bank', N'1', N'PL', N'1');
                                    INSERT [dbo].[Bank] ([BicOrSwift], [Name], [Code], [CountryCode], [NameAddressId]) VALUES (N'MBANKBPLPW', N'mBank', N'3', N'PL', N'3');
                                    INSERT [dbo].[Bank] ([BicOrSwift], [Name], [Code], [CountryCode], [NameAddressId]) VALUES (N'PKOBPLPW', N'PKO Bank Polski', N'2', N'PL', N'2');
                                    
                                    INSERT [dbo].[BankAccountInfo] ([BicOrSwift], [NameAddressId], [Name]) VALUES (N'INGBPLPW', N'1', N'ING Bank');
                                    INSERT [dbo].[BankAccountInfo] ([BicOrSwift], [NameAddressId], [Name]) VALUES (N'MBANKBPLPW', N'3', N'mBank');
                                    INSERT [dbo].[BankAccountInfo] ([BicOrSwift], [NameAddressId], [Name]) VALUES (N'PKOBPLPW', N'2', N'PKO Bank Polski');
                                    
                                    INSERT [dbo].[UserAccount] ([Login], [Password], [AccountNumber], [OwnerName]) VALUES (N'15963214', N'cbe0cd68cbca3868250c0ba545c48032f43eb0e8a5e6bab603d109251486f77a91e46a3146d887e37416c6bdb6cbe701bd514de778573c9b0068483c1c626aec', N'47105000282100002303150001', N'Mikołaj')
                                    INSERT [dbo].[AccountInfo] ([AccountNumber], [NameAddressId], [AccountType], [AccountHolderType], [AccountTypeName], [AccountNameClient], [Currency], [AvailableBalance], [BookingBalance], [BicOrSwift], [VatAccountNrb]) VALUES (N'47105000282100002303150001', N'2', N'1', 1, N'Konto Direct', N'Moje KONTO Direct', N'PLN', CAST(2714.80 AS Decimal(18, 2)), CAST(2714.80 AS Decimal(18, 2)), N'INGBPLPW', NULL);
                                    INSERT [dbo].[AccountInfo] ([AccountNumber], [NameAddressId], [AccountType], [AccountHolderType], [AccountTypeName], [AccountNameClient], [Currency], [AvailableBalance], [BookingBalance], [BicOrSwift], [VatAccountNrb]) VALUES (N'47105000282100002303150002', N'2', N'1', 1, N'Konto Direct', N'Na wakacje', N'PLN', CAST(2500 AS Decimal(18, 2)), CAST(2500 AS Decimal(18, 2)), N'INGBPLPW', NULL);

                                    INSERT INTO [dbo].[LinkedAccount] ([AccountNumber] ,[LinkedAccountNumber]) VALUES ('47105000282100002303150001', '47105000282100002303150002');

                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'25105000282100002303150009', NULL, N'INGBPLPW', N'1');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'47105000282100002303150001', NULL, N'PKOBPLPW', N'2');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'52105000282100000000000000', NULL, N'INGBPLPW', N'1');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'73105000282100002303150018', NULL, N'INGBPLPW', N'1');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'79105000282100002303130011', NULL, N'INGBPLPW', N'8');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'79105000282100002303150007', NULL, N'INGBPLPW', N'1');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'79105000282100002303550009', NULL, N'INGBPLPW', N'8');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'84105000282100002302271117', NULL, N'MBANKBPLPW', N'10');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'84105000282100002302555117', NULL, N'MBANKBPLPW', N'11');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'84105000282100002303150014', NULL, N'MBANKBPLPW', N'3');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'84105000282100002303170017', NULL, N'MBANKBPLPW', N'8');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'84105000282100002303170098', NULL, N'MBANKBPLPW', N'7');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'84105000282100002303171117', NULL, N'MBANKBPLPW', N'9');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'84105000282100042302555117', NULL, N'MBANKBPLPW', N'12');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'84105000282100042302555226', NULL, N'MBANKBPLPW', N'13');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'84105000282100042302555338', NULL, N'MBANKBPLPW', N'14');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'84105000282100042302555554', NULL, N'MBANKBPLPW', N'15');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'84105000282100042302555559', NULL, N'MBANKBPLPW', N'7');
                                    INSERT [dbo].[SenderRecipient] ([AccountNumber], [AccountMassPayment], [BicOrSwift], [NameAddressId]) VALUES (N'47105000282100002303150002', NULL, N'PKOBPLPW', N'2');

                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'1', CAST(50.00 AS Decimal(18, 2)), N'PLN', N'Darowizna', N'Standard', CAST(N'2021-09-02T00:00:00.0000000' AS DateTime2), NULL, 2, N'2', NULL, N'47105000282100002303150001', N'52105000282100000000000000', CAST(N'2021-09-02T00:00:00.0000000' AS DateTime2), CAST(2700.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'10', CAST(100.00 AS Decimal(18, 2)), N'PLN', N'Planszówki', N'Standard', CAST(N'2021-08-25T00:00:00.0000000' AS DateTime2), NULL, 2, N'2', NULL, N'47105000282100002303150001', N'84105000282100002302555117', CAST(N'2021-08-25T00:00:00.0000000' AS DateTime2), CAST(2750.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'11', CAST(3500.00 AS Decimal(18, 2)), N'PLN', N'Wynagrodzenie', N'Standard', CAST(N'2021-10-10T00:00:00.0000000' AS DateTime2), NULL, 1, N'2', NULL, N'84105000282100042302555117', N'47105000282100002303150001', CAST(N'2021-10-10T00:00:00.0000000' AS DateTime2), CAST(5500.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'12', CAST(500.00 AS Decimal(18, 2)), N'PLN', N'Czynsz', N'Standard', CAST(N'2021-10-12T00:00:00.0000000' AS DateTime2), NULL, 2, N'2', NULL, N'47105000282100002303150001', N'84105000282100042302555226', CAST(N'2021-10-12T00:00:00.0000000' AS DateTime2), CAST(5000.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'13', CAST(80.00 AS Decimal(18, 2)), N'PLN', N'Kino', N'Standard', CAST(N'2021-10-13T00:00:00.0000000' AS DateTime2), NULL, 2, N'2', NULL, N'47105000282100002303150001', N'84105000282100042302555338', CAST(N'2021-10-13T00:00:00.0000000' AS DateTime2), CAST(4920.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'14', CAST(120.00 AS Decimal(18, 2)), N'PLN', N'Teatr', N'Standard', CAST(N'2021-10-14T00:00:00.0000000' AS DateTime2), NULL, 2, N'2', NULL, N'47105000282100002303150001', N'84105000282100042302555554', CAST(N'2021-10-14T00:00:00.0000000' AS DateTime2), CAST(4800.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'2', CAST(200.00 AS Decimal(18, 2)), N'PLN', N'Paliwo', N'Standard', CAST(N'2021-09-02T00:00:00.0000000' AS DateTime2), NULL, 2, N'2', NULL, N'47105000282100002303150001', N'79105000282100002303150007', CAST(N'2021-09-02T00:00:00.0000000' AS DateTime2), CAST(2500.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'3', CAST(50.00 AS Decimal(18, 2)), N'PLN', N'Fryzjer', N'Standard', CAST(N'2021-09-04T00:00:00.0000000' AS DateTime2), NULL, 2, N'2', NULL, N'47105000282100002303150001', N'73105000282100002303150018', CAST(N'2021-09-06T00:00:00.0000000' AS DateTime2), CAST(2450.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'355f32ff-5b42-451d-8be2-edbf27c77ff7', CAST(10.00 AS Decimal(18, 2)), N'PLN', N'zasilenie', N'Standard', CAST(N'2021-10-14T22:24:30.7072696' AS DateTime2), NULL, 1, N'2', NULL, N'47105000282100002303150001', N'47105000282100002303150002', CAST(N'2021-10-14T22:24:30.7072696' AS DateTime2), CAST(2510.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'4', CAST(150.00 AS Decimal(18, 2)), N'PLN', N'Prąd', N'Standard', CAST(N'2021-09-04T00:00:00.0000000' AS DateTime2), NULL, 2, N'2', NULL, N'47105000282100002303150001', N'25105000282100002303150009', CAST(N'2021-09-06T00:00:00.0000000' AS DateTime2), CAST(2300.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'5', CAST(300.00 AS Decimal(18, 2)), N'PLN', N'Opony', N'Standard', CAST(N'2021-09-06T00:00:00.0000000' AS DateTime2), NULL, 2, N'2', NULL, N'47105000282100002303150001', N'84105000282100002303150014', CAST(N'2021-09-06T00:00:00.0000000' AS DateTime2), CAST(2000.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'6', CAST(3500.00 AS Decimal(18, 2)), N'PLN', N'Wynagrodzenie', N'Standard', CAST(N'2021-08-10T00:00:00.0000000' AS DateTime2), NULL, 1, N'2', NULL, N'84105000282100002303170098', N'47105000282100002303150001', CAST(N'2021-08-10T00:00:00.0000000' AS DateTime2), CAST(3500.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'7', CAST(500.00 AS Decimal(18, 2)), N'PLN', N'Czynsz', N'Standard', CAST(N'2021-08-12T00:00:00.0000000' AS DateTime2), NULL, 2, N'2', NULL, N'47105000282100002303150001', N'84105000282100002303170017', CAST(N'2021-08-12T00:00:00.0000000' AS DateTime2), CAST(3000.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'757fc958-d9af-4466-b9b6-c69cb64802a1', CAST(10.00 AS Decimal(18, 2)), N'PLN', N'zasilenie', N'Standard', CAST(N'2021-10-14T22:24:26.0000000' AS DateTime2), NULL, 2, N'2', NULL, N'47105000282100002303150001', N'47105000282100002303150002', CAST(N'2021-10-14T22:24:30.7072696' AS DateTime2), CAST(2814.80 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'8', CAST(400.00 AS Decimal(18, 2)), N'PLN', N'Rata kredytu', N'Standard', CAST(N'2021-08-12T00:00:00.0000000' AS DateTime2), NULL, 2, N'2', NULL, N'47105000282100002303150001', N'84105000282100002303171117', CAST(N'2021-08-12T00:00:00.0000000' AS DateTime2), CAST(2600.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'9', CAST(250.00 AS Decimal(18, 2)), N'PLN', N'Przypływ tówki', N'Standard', CAST(N'2021-08-20T00:00:00.0000000' AS DateTime2), NULL, 1, N'2', NULL, N'84105000282100002302271117', N'47105000282100002303150001', CAST(N'2021-08-20T00:00:00.0000000' AS DateTime2), CAST(2850.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'a8f3a32f-cee0-4527-b34a-d02a51dcc520', CAST(100.00 AS Decimal(18, 2)), N'PLN', N'zasilenie', N'Standard', CAST(N'2021-10-16T11:29:01.0000000' AS DateTime2), NULL, 2, N'2', NULL, N'47105000282100002303150001', N'47105000282100002303150002', CAST(N'2021-10-16T11:29:01.7447072' AS DateTime2), CAST(2714.80 AS Decimal(18, 2)))
                                    INSERT [dbo].[TransactionInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId], [BookingDate], [PostTransactionBalance]) VALUES (N'ea009556-dbb7-4b4b-8358-16c666fd6997', CAST(100.00 AS Decimal(18, 2)), N'PLN', N'zasilenie', N'Standard', CAST(N'2021-10-16T11:29:01.7447072' AS DateTime2), NULL, 1, N'2', NULL, N'47105000282100002303150001', N'47105000282100002303150002', CAST(N'2021-10-16T11:29:01.7447072' AS DateTime2), CAST(2610.00 AS Decimal(18, 2)))

                                    INSERT [dbo].[TransactionScheduledInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId]) VALUES (N'1', CAST(500.00 AS Decimal(18, 2)), N'PLN', N'Opłata za mieszkanie', N'Standard', CAST(N'2021-08-19T00:00:00.0000000' AS DateTime2), NULL, 2, N'6', NULL, N'47105000282100002303150001', N'84105000282100002303170098')
                                    INSERT [dbo].[TransactionScheduledInfo] ([ItemId], [Amount], [Currency], [Description], [TransactionType], [TradeDate], [Mcc], [TransactionCategory], [TransactionStatus], [Initiator], [SenderId], [RecipientId]) VALUES (N'2', CAST(300.00 AS Decimal(18, 2)), N'PLN', N'Rata kredytu', N'Standard', CAST(N'2021-09-25T00:00:00.0000000' AS DateTime2), NULL, 2, N'6', NULL, N'47105000282100002303150001', N'79105000282100002303550009')
                                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPsuRelation");

            migrationBuilder.DropTable(
                name: "LinkedAccount");

            migrationBuilder.DropTable(
                name: "TransactionCancelledInfo");

            migrationBuilder.DropTable(
                name: "TransactionInfo");

            migrationBuilder.DropTable(
                name: "TransactionPendingInfo");

            migrationBuilder.DropTable(
                name: "TransactionRejectedInfo");

            migrationBuilder.DropTable(
                name: "TransactionScheduledInfo");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "AccountInfo");

            migrationBuilder.DropTable(
                name: "SenderRecipient");

            migrationBuilder.DropTable(
                name: "BankAccountInfo");

            migrationBuilder.DropTable(
                name: "DictionaryItem");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "NameAddress");
        }
    }
}
