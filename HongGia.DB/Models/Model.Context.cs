﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HongGia.DB.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EntitiesDB : DbContext
    {
        public EntitiesDB()
            : base("name=EntitiesDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Catigory> Catigories { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Firm> Firms { get; set; }
        public virtual DbSet<FirmAddress> FirmAddresses { get; set; }
        public virtual DbSet<FirmContact> FirmContacts { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<PageContent> PageContents { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<TopicType> TopicTypes { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
    }
}
