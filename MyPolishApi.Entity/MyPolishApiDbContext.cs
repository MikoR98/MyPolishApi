using Microsoft.EntityFrameworkCore;
using MyPolishApi.Entity.Model.AccountInformationServiceModel;

namespace MyPolishApi.Entity
{
    public class MyPolishApiDbContext : DbContext
    {
        public MyPolishApiDbContext(DbContextOptions<MyPolishApiDbContext> options) : base(options)
        {
        }

        public DbSet<AccountInfo> AccountInfo { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public DbSet<BankAccountInfo> BankAccountInfo { get; set; }
        public DbSet<DictionaryItem> DictionaryItem { get; set; }
        public DbSet<NameAddress> NameAddress { get; set; }
        public DbSet<SenderRecipient> SenderRecipient { get; set; }
        public DbSet<LinkedAccount> LinkedAccount { get; set; }
        public DbSet<TransactionInfo> TransactionInfo { get; set; }
        public DbSet<TransactionPendingInfo> TransactionPendingInfo { get; set; }
        public DbSet<TransactionRejectedInfo> TransactionRejectedInfo { get; set; }
        public DbSet<TransactionCancelledInfo> TransactionCancelledInfo { get; set; }
        public DbSet<TransactionScheduledInfo> TransactionScheduledInfo { get; set; }
        public DbSet<AccountPsuRelation> AccountPsuRelation { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinkedAccount>().HasKey(c => new { c.AccountNumber, c.LinkedAccountNumber });

           modelBuilder.Entity<AccountInfo>()
                .HasOne(s => s.NameAddress)
                .WithOne(g => g.AccountInfo)
                .HasForeignKey<AccountInfo>(_ => _.NameAddressId);

            modelBuilder.Entity<AccountInfo>()
                .HasOne(s => s.DictionaryItem)
                .WithOne(g => g.AccountInfo)
                .HasForeignKey<AccountInfo>(_ => _.AccountType);

            modelBuilder.Entity<AccountInfo>()
                .HasOne(s => s.BankAccountInfo)
                .WithOne(g => g.AccountInfo)
                .HasForeignKey<AccountInfo>(_ => _.BicOrSwift);

            modelBuilder.Entity<AccountPsuRelation>()
                .HasOne(s => s.AccountInfo)
                .WithOne(g => g.PsuRelations)
                .HasForeignKey<AccountPsuRelation>(_ => _.AccountNumber);

            modelBuilder.Entity<LinkedAccount>()
                .HasOne(s => s.AccountInfo)
                .WithMany(g => g.LinkedAccount)
                .HasForeignKey(_ => _.AccountNumber);

            modelBuilder.Entity<BankAccountInfo>()
                .HasOne(s => s.NameAddress)
                .WithOne(g => g.BankAccountInfo)
                .HasForeignKey<BankAccountInfo>(_ => _.NameAddressId);

            modelBuilder.Entity<SenderRecipient>()
                .HasOne(s => s.NameAddress)
                .WithOne(g => g.SenderRecipient)
                .HasForeignKey<SenderRecipient>(_ => _.NameAddressId);

            modelBuilder.Entity<SenderRecipient>()
                .HasOne(s => s.Bank)
                .WithOne(g => g.SenderRecipient)
                .HasForeignKey<SenderRecipient>(_ => _.BicOrSwift);

            modelBuilder.Entity<Bank>()
                .HasOne(s => s.NameAddress)
                .WithOne(g => g.Bank)
                .HasForeignKey<Bank>(_ => _.NameAddressId);

            modelBuilder.Entity<TransactionInfo>()
                .HasOne(s => s.NameAddress)
                .WithOne(g => g.TransactionInfo)
                .HasForeignKey<TransactionInfo>(_ => _.Initiator);

            modelBuilder.Entity<TransactionInfo>()
                .HasOne(s => s.DictionaryItem)
                .WithOne(g => g.TransactionInfo)
                .HasForeignKey<TransactionInfo>(_ => _.TransactionStatus);

            modelBuilder.Entity<TransactionInfo>()
                .HasOne(s => s.Sender)
                .WithOne(g => g.TransactionInfoSender)
                .HasForeignKey<TransactionInfo>(_ => _.SenderId);

            modelBuilder.Entity<TransactionInfo>()
                .HasOne(s => s.Recipient)
                .WithOne(g => g.TransactionInfoRecipient)
                .HasForeignKey<TransactionInfo>(_ => _.RecipientId);

            modelBuilder.Entity<TransactionPendingInfo>()
                .HasOne(s => s.NameAddress)
                .WithOne(g => g.TransactionPendingInfo)
                .HasForeignKey<TransactionPendingInfo>(_ => _.Initiator);

            modelBuilder.Entity<TransactionPendingInfo>()
               .HasOne(s => s.Sender)
               .WithOne(g => g.TransactionPendingInfoSender)
               .HasForeignKey<TransactionPendingInfo>(_ => _.SenderId);

            modelBuilder.Entity<TransactionPendingInfo>()
                .HasOne(s => s.Recipient)
                .WithOne(g => g.TransactionPendingInfoRecipient)
                .HasForeignKey<TransactionPendingInfo>(_ => _.RecipientId);

            modelBuilder.Entity<TransactionRejectedInfo>()
                .HasOne(s => s.NameAddress)
                .WithOne(g => g.TransactionRejectedInfo)
                .HasForeignKey<TransactionRejectedInfo>(_ => _.Initiator);

            modelBuilder.Entity<TransactionRejectedInfo>()
               .HasOne(s => s.Sender)
               .WithOne(g => g.TransactionRejectedInfoSender)
               .HasForeignKey<TransactionRejectedInfo>(_ => _.SenderId);

            modelBuilder.Entity<TransactionRejectedInfo>()
                .HasOne(s => s.Recipient)
                .WithOne(g => g.TransactionRejectedInfoRecipient)
                .HasForeignKey<TransactionRejectedInfo>(_ => _.RecipientId);

            modelBuilder.Entity<TransactionCancelledInfo>()
                .HasOne(s => s.DictionaryItem)
                .WithOne(g => g.TransactionCancelledInfo)
                .HasForeignKey<TransactionCancelledInfo>(_ => _.TransactionStatus);

            modelBuilder.Entity<TransactionCancelledInfo>()
                .HasOne(s => s.NameAddress)
                .WithOne(g => g.TransactionCancelledInfo)
                .HasForeignKey<TransactionCancelledInfo>(_ => _.Initiator);

            modelBuilder.Entity<TransactionCancelledInfo>()
               .HasOne(s => s.Sender)
               .WithOne(g => g.TransactionCancelledInfoSender)
               .HasForeignKey<TransactionCancelledInfo>(_ => _.SenderId);

            modelBuilder.Entity<TransactionCancelledInfo>()
                .HasOne(s => s.Recipient)
                .WithOne(g => g.TransactionCancelledInfoRecipient)
                .HasForeignKey<TransactionCancelledInfo>(_ => _.RecipientId);

            modelBuilder.Entity<TransactionScheduledInfo>()
                .HasOne(s => s.DictionaryItem)
                .WithOne(g => g.TransactionScheduledInfo)
                .HasForeignKey<TransactionScheduledInfo>(_ => _.TransactionStatus);

            modelBuilder.Entity<TransactionScheduledInfo>()
                .HasOne(s => s.NameAddress)
                .WithOne(g => g.TransactionScheduledInfo)
                .HasForeignKey<TransactionScheduledInfo>(_ => _.Initiator);

            modelBuilder.Entity<TransactionScheduledInfo>()
               .HasOne(s => s.Sender)
               .WithOne(g => g.TransactionScheduledInfoSender)
               .HasForeignKey<TransactionScheduledInfo>(_ => _.SenderId);

            modelBuilder.Entity<TransactionScheduledInfo>()
                .HasOne(s => s.Recipient)
                .WithOne(g => g.TransactionScheduledInfoRecipient)
                .HasForeignKey<TransactionScheduledInfo>(_ => _.RecipientId);

            modelBuilder.Entity<Bank>()
                .HasIndex(_ => _.NameAddressId)
                .IsUnique(false)
                .HasFilter("[NameAddressId] IS NOT NULL");

            modelBuilder.Entity<BankAccountInfo>()
                .HasIndex(_ => _.NameAddressId)
                .IsUnique(false)
                .HasFilter("[NameAddressId] IS NOT NULL");

            modelBuilder.Entity<SenderRecipient>()
                .HasIndex(_ => _.NameAddressId)
                .IsUnique(false)
                .HasFilter("[NameAddressId] IS NOT NULL");

            modelBuilder.Entity<SenderRecipient>()
                .HasIndex(_ => _.BicOrSwift)
                .IsUnique(false)
                .HasFilter("[BicOrSwift] IS NOT NULL");

            modelBuilder.Entity<TransactionCancelledInfo>()
                .HasIndex(_ => _.Initiator)
                .IsUnique(false)
                .HasFilter("[Initiator] IS NOT NULL");

            modelBuilder.Entity<TransactionCancelledInfo>()
                .HasIndex(_ => _.RecipientId)
                .IsUnique(false)
                .HasFilter("[RecipientId] IS NOT NULL");

            modelBuilder.Entity<TransactionCancelledInfo>()
                .HasIndex(_ => _.SenderId)
                .IsUnique(false)
                .HasFilter("[SenderId] IS NOT NULL");

            modelBuilder.Entity<TransactionCancelledInfo>()
                .HasIndex(_ => _.TransactionStatus)
                .IsUnique(false)
                .HasFilter("[TransactionStatus] IS NOT NULL");

            modelBuilder.Entity<TransactionInfo>()
                .HasIndex(_ => _.Initiator)
                .IsUnique(false)
                .HasFilter("[Initiator] IS NOT NULL");

            modelBuilder.Entity<TransactionInfo>()
                .HasIndex(_ => _.RecipientId)
                .IsUnique(false)
                .HasFilter("[RecipientId] IS NOT NULL");

            modelBuilder.Entity<TransactionInfo>()
                .HasIndex(_ => _.SenderId)
                .IsUnique(false)
                .HasFilter("[SenderId] IS NOT NULL");

            modelBuilder.Entity<TransactionInfo>()
                .HasIndex(_ => _.TransactionStatus)
                .IsUnique(false)
                .HasFilter("[TransactionStatus] IS NOT NULL");

            modelBuilder.Entity<TransactionPendingInfo>()
                .HasIndex(_ => _.Initiator)
                .IsUnique(false)
                .HasFilter("[Initiator] IS NOT NULL");

            modelBuilder.Entity<TransactionPendingInfo>()
                .HasIndex(_ => _.RecipientId)
                .IsUnique(false)
                .HasFilter("[RecipientId] IS NOT NULL");

            modelBuilder.Entity<TransactionPendingInfo>()
                .HasIndex(_ => _.SenderId)
                .IsUnique(false)
                .HasFilter("[SenderId] IS NOT NULL");

            modelBuilder.Entity<TransactionRejectedInfo>()
                .HasIndex(_ => _.Initiator)
                .IsUnique(false)
                .HasFilter("[Initiator] IS NOT NULL");

            modelBuilder.Entity<TransactionRejectedInfo>()
                .HasIndex(_ => _.RecipientId)
                .IsUnique(false)
                .HasFilter("[RecipientId] IS NOT NULL");

            modelBuilder.Entity<TransactionRejectedInfo>()
                .HasIndex(_ => _.SenderId)
                .IsUnique(false)
                .HasFilter("[SenderId] IS NOT NULL");

            modelBuilder.Entity<TransactionScheduledInfo>()
                .HasIndex(_ => _.Initiator)
                .IsUnique(false)
                .HasFilter("[Initiator] IS NOT NULL");

            modelBuilder.Entity<TransactionScheduledInfo>()
                .HasIndex(_ => _.RecipientId)
                .IsUnique(false)
                .HasFilter("[RecipientId] IS NOT NULL");

            modelBuilder.Entity<TransactionScheduledInfo>()
                .HasIndex(_ => _.SenderId)
                .IsUnique(false)
                .HasFilter("[SenderId] IS NOT NULL");

            modelBuilder.Entity<TransactionScheduledInfo>()
               .HasIndex(_ => _.TransactionStatus)
               .IsUnique(false)
               .HasFilter("[TransactionStatus] IS NOT NULL");

            modelBuilder.Entity<AccountInfo>()
               .HasIndex(_ => _.AccountType)
               .IsUnique(false)
               .HasFilter("[AccountType] IS NOT NULL");

            modelBuilder.Entity<AccountInfo>()
               .HasIndex(_ => _.BicOrSwift)
               .IsUnique(false)
               .HasFilter("[BicOrSwift] IS NOT NULL");

            modelBuilder.Entity<AccountInfo>()
               .HasIndex(_ => _.NameAddressId)
               .IsUnique(false)
               .HasFilter("[NameAddressId] IS NOT NULL");

            modelBuilder.Entity<LinkedAccount>()
               .HasIndex(_ => _.AccountNumber)
               .IsUnique(false);
        }
    }
}
