//===============================================================================
// Microsoft Premier Support for Developers
// FeatureToggle Sample
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using Pubs.Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Pubs.Data.Context
{
    /// <summary>
    /// Entity framework database context for the Pubs database
    /// </summary>
    public class PubsContext : DbContext
    {
        /// <summary>
        /// Constructor -
        /// </summary>
        public PubsContext() : base("pubs")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// DbSet of <see cref="Pubs.Data.Models.Author"/>
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// DbSet of <see cref="Pubs.Data.Model.Author"/>
        /// </summary>
        public DbSet<Publisher> Publishers { get; set; }

        /// <summary>
        /// DbSet of <see cref="Pubs.Data.Models.Author"/>
        /// </summary>
        public DbSet<Title> Titles { get; set; }

        /// <summary>
        /// Configure the mapping of database tables to entities
        /// </summary>
        /// <param name="modelBuilder"><see cref="System.Data.Entity.DbModelBuilder"/></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Author mapping
            EntityTypeConfiguration<Author> author = modelBuilder.Entity<Author>();
            author.ToTable("authors");
            author.Property(a => a.AuthorID).HasColumnName("au_id");
            author.Property(a => a.FirstName).HasColumnName("au_fname");
            author.Property(a => a.LastName).HasColumnName("au_lname");
            author.Ignore(a => a.Name);
            author.Property(a => a.PhoneNumber).HasColumnName("phone");
            author.Property(a => a.Address).HasColumnName("address");
            author.Property(a => a.City).HasColumnName("city");
            author.Property(a => a.State).HasColumnName("state");
            author.Property(a => a.PostalCode).HasColumnName("zip");
            author.Property(a => a.HasContract).HasColumnName("contract");
            author.Ignore(a => a.YearToDateSales);
            author.HasKey(a => a.AuthorID);

            // Publisher mapping
            EntityTypeConfiguration<Publisher> publisher = modelBuilder.Entity<Publisher>();
            publisher.ToTable("publishers");
            publisher.Property(p => p.PublisherID).HasColumnName("pub_id");
            publisher.Property(p => p.Name).HasColumnName("pub_name");
            publisher.Property(p => p.City).HasColumnName("city");
            publisher.Property(p => p.State).HasColumnName("state");
            publisher.Property(p => p.Country).HasColumnName("country");
            publisher.Ignore(p => p.YearToDateSales);
            publisher.HasKey(p => p.PublisherID);

            // Title mapping
            EntityTypeConfiguration<Title> title = modelBuilder.Entity<Title>();
            title.ToTable("titles");
            title.Property(t => t.TitleID).HasColumnName("title_id");
            title.Property(t => t.BookTitle).HasColumnName("title");
            title.Property(t => t.Type).HasColumnName("type");
            title.Property(t => t.Price).HasColumnName("price");
            title.Property(t => t.Advance).HasColumnName("advance");
            title.Property(t => t.Royalty).HasColumnName("royalty");
            title.Property(t => t.YearToDateSales).HasColumnName("ytd_sales");
            title.Property(t => t.Notes).HasColumnName("notes");
            title.Property(t => t.PublishDate).HasColumnName("pubdate");
            title.HasRequired(t => t.Publisher).WithMany(p => p.Titles).Map(pt => pt.MapKey("pub_id"));
            title.HasMany(t => t.Authors).WithMany(a => a.Titles).Map(at => { at.ToTable("titleauthor"); at.MapLeftKey("title_id"); at.MapRightKey("au_id"); });
            title.HasKey(t => t.TitleID);
        }
    }
}
