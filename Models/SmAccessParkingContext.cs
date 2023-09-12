using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace smartapi.Models;

public partial class SmAccessParkingContext : DbContext
{
    public SmAccessParkingContext()
    {
    }

    public SmAccessParkingContext(DbContextOptions<SmAccessParkingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessController> AccessControllers { get; set; }

    public virtual DbSet<AccessControllerBrandSystem> AccessControllerBrandSystems { get; set; }

    public virtual DbSet<AccessControllerModel> AccessControllerModels { get; set; }

    public virtual DbSet<AccessControllerNetwork> AccessControllerNetworks { get; set; }

    public virtual DbSet<AccessEvent> AccessEvents { get; set; }

    public virtual DbSet<AccessRight> AccessRights { get; set; }

    public virtual DbSet<AccessRightDoor> AccessRightDoors { get; set; }

    public virtual DbSet<AccessRightHolder> AccessRightHolders { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<CardHolder> CardHolders { get; set; }

    public virtual DbSet<CitizenIdCard> CitizenIdCards { get; set; }

    public virtual DbSet<Door> Doors { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<Period> Periods { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=SM_Access_Parking;Username=postgres;Password=Manh1993@");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessController>(entity =>
        {
            entity.HasKey(e => e.CtrlrId).HasName("access_controller_pkey");

            entity.ToTable("access_controller");

            entity.HasIndex(e => e.CtrlrName, "access_controller_ctrlr_name_key").IsUnique();

            entity.Property(e => e.CtrlrId).HasColumnName("ctrlr_id");
            entity.Property(e => e.CtrlrDgw)
                .HasMaxLength(15)
                .HasComment("default gateway")
                .HasColumnName("ctrlr_dgw");
            entity.Property(e => e.CtrlrIp)
                .HasMaxLength(15)
                .HasColumnName("ctrlr_ip");
            entity.Property(e => e.CtrlrLnaddr)
                .HasComment("line address")
                .HasColumnName("ctrlr_lnaddr");
            entity.Property(e => e.CtrlrMac)
                .HasMaxLength(17)
                .IsFixedLength()
                .HasColumnName("ctrlr_mac");
            entity.Property(e => e.CtrlrName)
                .HasMaxLength(50)
                .HasColumnName("ctrlr_name");
            entity.Property(e => e.CtrlrSnm)
                .HasMaxLength(15)
                .HasComment("subnet mask")
                .HasColumnName("ctrlr_snm");
            entity.Property(e => e.Descr)
                .HasMaxLength(100)
                .HasColumnName("descr");
            entity.Property(e => e.Ext1)
                .HasMaxLength(1000)
                .HasColumnName("ext1");
            entity.Property(e => e.Ext10)
                .HasMaxLength(1000)
                .HasColumnName("ext10");
            entity.Property(e => e.Ext2)
                .HasMaxLength(1000)
                .HasColumnName("ext2");
            entity.Property(e => e.Ext3)
                .HasMaxLength(1000)
                .HasColumnName("ext3");
            entity.Property(e => e.Ext4)
                .HasMaxLength(1000)
                .HasColumnName("ext4");
            entity.Property(e => e.Ext5)
                .HasMaxLength(1000)
                .HasColumnName("ext5");
            entity.Property(e => e.Ext6)
                .HasMaxLength(1000)
                .HasColumnName("ext6");
            entity.Property(e => e.Ext7)
                .HasMaxLength(1000)
                .HasColumnName("ext7");
            entity.Property(e => e.Ext8)
                .HasMaxLength(1000)
                .HasColumnName("ext8");
            entity.Property(e => e.Ext9)
                .HasMaxLength(1000)
                .HasColumnName("ext9");
            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.NetworkId).HasColumnName("network_id");
            entity.Property(e => e.ParentCtlr).HasColumnName("parent_ctlr");

            entity.HasOne(d => d.Model).WithMany(p => p.AccessControllers)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("access_controller_model_id_fkey");

            entity.HasOne(d => d.Network).WithMany(p => p.AccessControllers)
                .HasForeignKey(d => d.NetworkId)
                .HasConstraintName("access_controller_network_id_fkey");

            entity.HasOne(d => d.ParentCtlrNavigation).WithMany(p => p.InverseParentCtlrNavigation)
                .HasForeignKey(d => d.ParentCtlr)
                .HasConstraintName("access_controller_parent_ctlr_fkey");
        });

        modelBuilder.Entity<AccessControllerBrandSystem>(entity =>
        {
            entity.HasKey(e => e.BrId).HasName("access_controller_brand_system_pkey");

            entity.ToTable("access_controller_brand_system");

            entity.Property(e => e.BrId).HasColumnName("br_id");
            entity.Property(e => e.BrName)
                .HasMaxLength(50)
                .HasColumnName("br_name");
            entity.Property(e => e.Logo).HasColumnName("logo");
        });

        modelBuilder.Entity<AccessControllerModel>(entity =>
        {
            entity.HasKey(e => e.ModelId).HasName("access_controller_models_pkey");

            entity.ToTable("access_controller_models");

            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.BrId).HasColumnName("br_id");
            entity.Property(e => e.Catalog)
                .HasMaxLength(100)
                .HasColumnName("catalog");
            entity.Property(e => e.Descr)
                .HasMaxLength(100)
                .HasColumnName("descr");
            entity.Property(e => e.InputQty).HasColumnName("input_qty");
            entity.Property(e => e.ModelName)
                .HasMaxLength(50)
                .HasColumnName("model_name");
            entity.Property(e => e.OutQty).HasColumnName("out_qty");
            entity.Property(e => e.PartNo)
                .HasMaxLength(50)
                .HasColumnName("part_no");
            entity.Property(e => e.ReaderQty).HasColumnName("reader_qty");
            entity.Property(e => e.UserGuide)
                .HasMaxLength(100)
                .HasColumnName("user_guide");

            entity.HasOne(d => d.Br).WithMany(p => p.AccessControllerModels)
                .HasForeignKey(d => d.BrId)
                .HasConstraintName("access_controller_models_br_id_fkey");
        });

        modelBuilder.Entity<AccessControllerNetwork>(entity =>
        {
            entity.HasKey(e => e.NetworkId).HasName("access_controller_network_pkey");

            entity.ToTable("access_controller_network");

            entity.Property(e => e.NetworkId).HasColumnName("network_id");
            entity.Property(e => e.Adapter)
                .HasMaxLength(100)
                .HasColumnName("adapter");
            entity.Property(e => e.BrId).HasColumnName("br_id");
            entity.Property(e => e.Ext1)
                .HasMaxLength(1000)
                .HasColumnName("ext1");
            entity.Property(e => e.Ext10)
                .HasMaxLength(1000)
                .HasColumnName("ext10");
            entity.Property(e => e.Ext2)
                .HasMaxLength(1000)
                .HasColumnName("ext2");
            entity.Property(e => e.Ext3)
                .HasMaxLength(1000)
                .HasColumnName("ext3");
            entity.Property(e => e.Ext4)
                .HasMaxLength(1000)
                .HasColumnName("ext4");
            entity.Property(e => e.Ext5)
                .HasMaxLength(1000)
                .HasColumnName("ext5");
            entity.Property(e => e.Ext6)
                .HasMaxLength(1000)
                .HasColumnName("ext6");
            entity.Property(e => e.Ext7)
                .HasMaxLength(1000)
                .HasColumnName("ext7");
            entity.Property(e => e.Ext8)
                .HasMaxLength(1000)
                .HasColumnName("ext8");
            entity.Property(e => e.Ext9)
                .HasMaxLength(1000)
                .HasColumnName("ext9");
            entity.Property(e => e.NetworkName)
                .HasMaxLength(50)
                .HasColumnName("network_name");

            entity.HasOne(d => d.Br).WithMany(p => p.AccessControllerNetworks)
                .HasForeignKey(d => d.BrId)
                .HasConstraintName("access_controller_network_br_id_fkey");
        });

        modelBuilder.Entity<AccessEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("access_event_pkey");

            entity.ToTable("access_event");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.CardNo)
                .HasMaxLength(20)
                .HasColumnName("card_no");
            entity.Property(e => e.ChId).HasColumnName("ch_id");
            entity.Property(e => e.ChName)
                .HasMaxLength(50)
                .HasComment("Card holder full name")
                .HasColumnName("ch_name");
            entity.Property(e => e.DoorId).HasColumnName("door_id");
            entity.Property(e => e.DoorName)
                .HasMaxLength(50)
                .HasColumnName("door_name");
            entity.Property(e => e.EventDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("event_date");
            entity.Property(e => e.EventStt)
                .HasComment("0=Granted; 1=Not grant; 2=Other")
                .HasColumnName("event_stt");
            entity.Property(e => e.Orientation)
                .HasComment("0=In; 1=Out")
                .HasColumnName("orientation");

            entity.HasOne(d => d.Card).WithMany(p => p.AccessEvents)
                .HasForeignKey(d => d.CardId)
                .HasConstraintName("access_event_card_id_fkey");

            entity.HasOne(d => d.Ch).WithMany(p => p.AccessEvents)
                .HasForeignKey(d => d.ChId)
                .HasConstraintName("access_event_ch_id_fkey");

            entity.HasOne(d => d.Door).WithMany(p => p.AccessEvents)
                .HasForeignKey(d => d.DoorId)
                .HasConstraintName("access_event_door_id_fkey");
        });

        modelBuilder.Entity<AccessRight>(entity =>
        {
            entity.HasKey(e => e.RightId).HasName("access_right_pkey");

            entity.ToTable("access_right");

            entity.Property(e => e.RightId).HasColumnName("right_id");
            entity.Property(e => e.Descr)
                .HasMaxLength(100)
                .HasColumnName("descr");
            entity.Property(e => e.IsEnable).HasColumnName("is_enable");
            entity.Property(e => e.RightName)
                .HasMaxLength(50)
                .HasColumnName("right_name");
            entity.Property(e => e.SchId).HasColumnName("sch_id");

            entity.HasOne(d => d.Sch).WithMany(p => p.AccessRights)
                .HasForeignKey(d => d.SchId)
                .HasConstraintName("access_right_sch_id_fkey");
        });

        modelBuilder.Entity<AccessRightDoor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("access_right_door_pkey");

            entity.ToTable("access_right_door");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DoorId).HasColumnName("door_id");
            entity.Property(e => e.RightId).HasColumnName("right_id");

            entity.HasOne(d => d.Door).WithMany(p => p.AccessRightDoors)
                .HasForeignKey(d => d.DoorId)
                .HasConstraintName("access_right_door_door_id_fkey");

            entity.HasOne(d => d.Right).WithMany(p => p.AccessRightDoors)
                .HasForeignKey(d => d.RightId)
                .HasConstraintName("access_right_door_right_id_fkey");
        });

        modelBuilder.Entity<AccessRightHolder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("access_right_holder_pkey");

            entity.ToTable("access_right_holder");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChId).HasColumnName("ch_id");
            entity.Property(e => e.RightId).HasColumnName("right_id");

            entity.HasOne(d => d.Ch).WithMany(p => p.AccessRightHolders)
                .HasForeignKey(d => d.ChId)
                .HasConstraintName("access_right_holder_ch_id_fkey");

            entity.HasOne(d => d.Right).WithMany(p => p.AccessRightHolders)
                .HasForeignKey(d => d.RightId)
                .HasConstraintName("access_right_holder_right_id_fkey");
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("card_pkey");

            entity.ToTable("card");

            entity.HasIndex(e => e.CardNo, "card_card_no_key").IsUnique();

            entity.HasIndex(e => e.PrintCardId, "card_print_card_id_key").IsUnique();

            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.CardNo)
                .HasMaxLength(20)
                .HasColumnName("card_no");
            entity.Property(e => e.CardState)
                .HasComment("0=Normal; 1=Lost...")
                .HasColumnName("card_state");
            entity.Property(e => e.CardType)
                .HasComment("0=Daily; 1=Monthly")
                .HasColumnName("card_type");
            entity.Property(e => e.ChId).HasColumnName("ch_id");
            entity.Property(e => e.Descr)
                .HasMaxLength(100)
                .HasColumnName("descr");
            entity.Property(e => e.ExpDate).HasColumnName("exp_date");
            entity.Property(e => e.IssDate).HasColumnName("iss_date");
            entity.Property(e => e.PrintCardId)
                .HasMaxLength(12)
                .HasColumnName("print_card_id");
            entity.Property(e => e.VldDate).HasColumnName("vld_date");

            entity.HasOne(d => d.Ch).WithMany(p => p.Cards)
                .HasForeignKey(d => d.ChId)
                .HasConstraintName("card_ch_id_fkey");
        });

        modelBuilder.Entity<CardHolder>(entity =>
        {
            entity.HasKey(e => e.ChId).HasName("card_holder_pkey");

            entity.ToTable("card_holder");

            entity.Property(e => e.ChId).HasColumnName("ch_id");
            entity.Property(e => e.ChAddr)
                .HasMaxLength(100)
                .HasColumnName("ch_addr");
            entity.Property(e => e.ChDob)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ch_DOB");
            entity.Property(e => e.ChEmail)
                .HasMaxLength(50)
                .HasColumnName("ch_email");
            entity.Property(e => e.ChFname)
                .HasMaxLength(50)
                .HasColumnName("ch_fname");
            entity.Property(e => e.ChGender)
                .HasComment("0 = Male; 1 = Female; 2 = Other")
                .HasColumnName("ch_gender");
            entity.Property(e => e.ChLname)
                .HasMaxLength(50)
                .HasColumnName("ch_lname");
            entity.Property(e => e.ChPhotos).HasColumnName("ch_photos");
            entity.Property(e => e.ChTel)
                .HasMaxLength(15)
                .HasColumnName("ch_tel");
            entity.Property(e => e.ChType).HasColumnName("ch_type");
            entity.Property(e => e.FacId).HasColumnName("fac_id");

            entity.HasOne(d => d.Fac).WithMany(p => p.CardHolders)
                .HasForeignKey(d => d.FacId)
                .HasConstraintName("card_holder_fac_id_fkey");
        });

        modelBuilder.Entity<CitizenIdCard>(entity =>
        {
            entity.HasKey(e => e.ChId).HasName("citizen_id_card_pkey");

            entity.ToTable("citizen_id_card");

            entity.Property(e => e.ChId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ch_id");
            entity.Property(e => e.DateOfIssue).HasColumnName("date_of_issue");
            entity.Property(e => e.IdNo)
                .HasMaxLength(20)
                .HasColumnName("id_no");
            entity.Property(e => e.Nationality)
                .HasMaxLength(50)
                .HasColumnName("nationality");
            entity.Property(e => e.PlaceOfIssue)
                .HasMaxLength(100)
                .HasColumnName("place_of_issue");
            entity.Property(e => e.PlaceOfOrigin)
                .HasMaxLength(100)
                .HasColumnName("place_of_origin");

            entity.HasOne(d => d.Ch).WithOne(p => p.CitizenIdCard)
                .HasForeignKey<CitizenIdCard>(d => d.ChId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("citizen_id_card_ch_id_fkey");
        });

        modelBuilder.Entity<Door>(entity =>
        {
            entity.HasKey(e => e.DoorId).HasName("door_pkey");

            entity.ToTable("door");

            entity.Property(e => e.DoorId).HasColumnName("door_id");
            entity.Property(e => e.CnctCtrlrId).HasColumnName("cnct_ctrlr_id");
            entity.Property(e => e.Descr)
                .HasMaxLength(100)
                .HasColumnName("descr");
            entity.Property(e => e.DoTo)
                .HasComment("DO time out")
                .HasColumnName("do_to");
            entity.Property(e => e.DoorEnable).HasColumnName("door_enable");
            entity.Property(e => e.DoorMode).HasColumnName("door_mode");
            entity.Property(e => e.DoorName)
                .HasMaxLength(50)
                .HasColumnName("door_name");
            entity.Property(e => e.LoTo)
                .HasComment("LO time out")
                .HasColumnName("lo_to");
            entity.Property(e => e.PButtonStt).HasColumnName("p_button_stt");
            entity.Property(e => e.PDoor2Stt).HasColumnName("p_door2_stt");
            entity.Property(e => e.PDoorStt).HasColumnName("p_door_stt");
            entity.Property(e => e.PFireAlarm).HasColumnName("p_fire_alarm");
            entity.Property(e => e.PInput).HasColumnName("p_input");
            entity.Property(e => e.PLockCtrl).HasColumnName("p_lock_ctrl");
            entity.Property(e => e.POutput).HasColumnName("p_output");
            entity.Property(e => e.PSiren).HasColumnName("p_siren");

            entity.HasOne(d => d.CnctCtrlr).WithMany(p => p.Doors)
                .HasForeignKey(d => d.CnctCtrlrId)
                .HasConstraintName("door_cnct_ctrlr_id_fkey");
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.HasKey(e => e.FacId).HasName("facility_pkey");

            entity.ToTable("facility");

            entity.Property(e => e.FacId).HasColumnName("fac_id");
            entity.Property(e => e.EmailAddr)
                .HasMaxLength(50)
                .HasColumnName("email_addr");
            entity.Property(e => e.FacAddr)
                .HasMaxLength(100)
                .HasColumnName("fac_addr");
            entity.Property(e => e.FacLogo).HasColumnName("fac_logo");
            entity.Property(e => e.FacName)
                .HasMaxLength(50)
                .HasColumnName("fac_name");
            entity.Property(e => e.FacPhoneNo)
                .HasMaxLength(20)
                .HasColumnName("fac_phone_no");
            entity.Property(e => e.ParentFacId).HasColumnName("parent_fac_id");

            entity.HasOne(d => d.ParentFac).WithMany(p => p.InverseParentFac)
                .HasForeignKey(d => d.ParentFacId)
                .HasConstraintName("facility_parent_fac_id_fkey");
        });

        modelBuilder.Entity<Period>(entity =>
        {
            entity.HasKey(e => e.PrdId).HasName("period_pkey");

            entity.ToTable("period");

            entity.Property(e => e.PrdId).HasColumnName("prd_id");
            entity.Property(e => e.EndHour).HasColumnName("end_hour");
            entity.Property(e => e.EndMinute).HasColumnName("end_minute");
            entity.Property(e => e.SchId).HasColumnName("sch_id");
            entity.Property(e => e.StartHour).HasColumnName("start_hour");
            entity.Property(e => e.StartMinute).HasColumnName("start_minute");
            entity.Property(e => e.WeekDay)
                .HasComment("Sun=0; Mon=1...; Sat=6")
                .HasColumnName("week_day");

            entity.HasOne(d => d.Sch).WithMany(p => p.Periods)
                .HasForeignKey(d => d.SchId)
                .HasConstraintName("period_sch_id_fkey");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.SchId).HasName("schedule_pkey");

            entity.ToTable("schedule");

            entity.Property(e => e.SchId).HasColumnName("sch_id");
            entity.Property(e => e.Descr)
                .HasMaxLength(100)
                .HasColumnName("descr");
            entity.Property(e => e.SchEnable).HasColumnName("sch_enable");
            entity.Property(e => e.SchName)
                .HasMaxLength(50)
                .HasColumnName("sch_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsrId).HasName("user_pkey");

            entity.ToTable("user");

            entity.HasIndex(e => e.UsrAcct, "user_usr_acct_key").IsUnique();

            entity.Property(e => e.UsrId).HasColumnName("usr_id");
            entity.Property(e => e.UsrAcct)
                .HasMaxLength(16)
                .HasColumnName("usr_acct");
            entity.Property(e => e.UsrDept)
                .HasMaxLength(100)
                .HasColumnName("usr_dept");
            entity.Property(e => e.UsrFname)
                .HasMaxLength(50)
                .HasColumnName("usr_fname");
            entity.Property(e => e.UsrLname)
                .HasMaxLength(50)
                .HasColumnName("usr_lname");
            entity.Property(e => e.UsrPwd)
                .HasMaxLength(16)
                .HasColumnName("usr_pwd");
            entity.Property(e => e.UsrTel)
                .HasMaxLength(15)
                .HasColumnName("usr_tel");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
