﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using lounga.Data;

#nullable disable

namespace lounga.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220914042252_updatedatacontext")]
    partial class updatedatacontext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookingHotelRoom", b =>
                {
                    b.Property<int>("BookingHotelsId")
                        .HasColumnType("integer");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.HasKey("BookingHotelsId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("BookingHotelRoom");
                });

            modelBuilder.Entity("lounga.Model.Aircraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AircraftsType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("AirlineId")
                        .HasColumnType("integer");

                    b.Property<int>("AmountPassenger")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("SeatCapacity")
                        .HasColumnType("integer");

                    b.Property<string>("SeatLayout")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SeatPitch")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AirlineId");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("lounga.Model.Airline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DestinationFrom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DestinationTo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SeatClass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("lounga.Model.BookingFlight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AircraftId")
                        .HasColumnType("integer");

                    b.Property<int?>("AirlineId")
                        .HasColumnType("integer");

                    b.Property<int>("AmountPassenger")
                        .HasColumnType("integer");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("FlightId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AircraftId");

                    b.HasIndex("AirlineId");

                    b.HasIndex("FlightId");

                    b.HasIndex("UserId");

                    b.ToTable("BookingFlights");
                });

            modelBuilder.Entity("lounga.Model.BookingHotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("HotelId")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("TotalRoom")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("UserId");

                    b.ToTable("BookingHotels");
                });

            modelBuilder.Entity("lounga.Model.FacilitiesAircraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AircraftId")
                        .HasColumnType("integer");

                    b.Property<int>("Baggage")
                        .HasColumnType("integer");

                    b.Property<int>("CabinBaggage")
                        .HasColumnType("integer");

                    b.Property<bool>("Entertainment")
                        .HasColumnType("boolean");

                    b.Property<bool>("PowerPort")
                        .HasColumnType("boolean");

                    b.Property<bool>("Wifi")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AircraftId")
                        .IsUnique();

                    b.ToTable("FacilitiesAircrafts");
                });

            modelBuilder.Entity("lounga.Model.FacilitiesHotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AirConditioner")
                        .HasColumnType("boolean");

                    b.Property<bool>("Gym")
                        .HasColumnType("boolean");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<bool>("Parking")
                        .HasColumnType("boolean");

                    b.Property<bool>("Playground")
                        .HasColumnType("boolean");

                    b.Property<bool>("Pool")
                        .HasColumnType("boolean");

                    b.Property<bool>("Restaurant")
                        .HasColumnType("boolean");

                    b.Property<bool>("Spa")
                        .HasColumnType("boolean");

                    b.Property<bool>("Television")
                        .HasColumnType("boolean");

                    b.Property<bool>("Wifi")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("HotelId")
                        .IsUnique();

                    b.ToTable("FacilitiesHotels");
                });

            modelBuilder.Entity("lounga.Model.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Aircraft")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AircraftsType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Airline")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AmountPassenger")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DestinationFrom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DestinationTo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("FacilitiesAircraftId")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("SeatCapacity")
                        .HasColumnType("integer");

                    b.Property<string>("SeatClass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SeatLayout")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SeatPitch")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FacilitiesAircraftId");

                    b.ToTable("flights");
                });

            modelBuilder.Entity("lounga.Model.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingHotelId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookingHotelId")
                        .IsUnique();

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("lounga.Model.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("lounga.Model.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookingFlightId")
                        .HasColumnType("integer");

                    b.Property<string>("IdCard")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookingFlightId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("lounga.Model.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("HotelId")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("lounga.Model.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("HotelId")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("lounga.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookingHotelRoom", b =>
                {
                    b.HasOne("lounga.Model.BookingHotel", null)
                        .WithMany()
                        .HasForeignKey("BookingHotelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lounga.Model.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("lounga.Model.Aircraft", b =>
                {
                    b.HasOne("lounga.Model.Airline", "Airline")
                        .WithMany("Aircrafts")
                        .HasForeignKey("AirlineId");

                    b.Navigation("Airline");
                });

            modelBuilder.Entity("lounga.Model.BookingFlight", b =>
                {
                    b.HasOne("lounga.Model.Aircraft", "Aircraft")
                        .WithMany("BookingFlights")
                        .HasForeignKey("AircraftId");

                    b.HasOne("lounga.Model.Airline", "Airline")
                        .WithMany("BookingFlights")
                        .HasForeignKey("AirlineId");

                    b.HasOne("lounga.Model.Flight", null)
                        .WithMany("BookingFlights")
                        .HasForeignKey("FlightId");

                    b.HasOne("lounga.Model.User", "User")
                        .WithMany("BookingFlights")
                        .HasForeignKey("UserId");

                    b.Navigation("Aircraft");

                    b.Navigation("Airline");

                    b.Navigation("User");
                });

            modelBuilder.Entity("lounga.Model.BookingHotel", b =>
                {
                    b.HasOne("lounga.Model.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId");

                    b.HasOne("lounga.Model.User", "User")
                        .WithMany("BookingHotels")
                        .HasForeignKey("UserId");

                    b.Navigation("Hotel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("lounga.Model.FacilitiesAircraft", b =>
                {
                    b.HasOne("lounga.Model.Aircraft", "Aircraft")
                        .WithOne("FacilitiesAircraft")
                        .HasForeignKey("lounga.Model.FacilitiesAircraft", "AircraftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");
                });

            modelBuilder.Entity("lounga.Model.FacilitiesHotel", b =>
                {
                    b.HasOne("lounga.Model.Hotel", "Hotel")
                        .WithOne("FacilitiesHotel")
                        .HasForeignKey("lounga.Model.FacilitiesHotel", "HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("lounga.Model.Flight", b =>
                {
                    b.HasOne("lounga.Model.FacilitiesAircraft", "FacilitiesAircraft")
                        .WithMany()
                        .HasForeignKey("FacilitiesAircraftId");

                    b.Navigation("FacilitiesAircraft");
                });

            modelBuilder.Entity("lounga.Model.Guest", b =>
                {
                    b.HasOne("lounga.Model.BookingHotel", "BookingHotel")
                        .WithOne("Guest")
                        .HasForeignKey("lounga.Model.Guest", "BookingHotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingHotel");
                });

            modelBuilder.Entity("lounga.Model.Passenger", b =>
                {
                    b.HasOne("lounga.Model.BookingFlight", "BookingFlight")
                        .WithMany("Passengers")
                        .HasForeignKey("BookingFlightId");

                    b.Navigation("BookingFlight");
                });

            modelBuilder.Entity("lounga.Model.Photo", b =>
                {
                    b.HasOne("lounga.Model.Hotel", "Hotel")
                        .WithMany("Photos")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("lounga.Model.Room", b =>
                {
                    b.HasOne("lounga.Model.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("lounga.Model.Aircraft", b =>
                {
                    b.Navigation("BookingFlights");

                    b.Navigation("FacilitiesAircraft");
                });

            modelBuilder.Entity("lounga.Model.Airline", b =>
                {
                    b.Navigation("Aircrafts");

                    b.Navigation("BookingFlights");
                });

            modelBuilder.Entity("lounga.Model.BookingFlight", b =>
                {
                    b.Navigation("Passengers");
                });

            modelBuilder.Entity("lounga.Model.BookingHotel", b =>
                {
                    b.Navigation("Guest");
                });

            modelBuilder.Entity("lounga.Model.Flight", b =>
                {
                    b.Navigation("BookingFlights");
                });

            modelBuilder.Entity("lounga.Model.Hotel", b =>
                {
                    b.Navigation("FacilitiesHotel");

                    b.Navigation("Photos");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("lounga.Model.User", b =>
                {
                    b.Navigation("BookingFlights");

                    b.Navigation("BookingHotels");
                });
#pragma warning restore 612, 618
        }
    }
}
