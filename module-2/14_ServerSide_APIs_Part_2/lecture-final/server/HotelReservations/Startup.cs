﻿using System;
using HotelReservations.Dao;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservations
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Add CORS policy allowing any origin
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                  builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            // TODO 04: Configure Dependency injection so the controller doesn't have to 
            //          create the dao's inside the controller.

            // we need to tell MVC, "If you ever need an IHotelDao, create a new HotelFakeDao"
            services.AddTransient<IHotelDao, HotelFakeDao>();

            // Same with IReservationDao --> ReservationFakeDao
            //services.AddTransient<IReservationDao, ReservationFakeDao>( sp => {
            //    return new ReservationFakeDao();
            //});
            services.AddTransient<IReservationDao, ReservationFakeDao>(GetResDao);


        }

        private ReservationFakeDao GetResDao(IServiceProvider sp)
        {
            return new ReservationFakeDao();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
