using DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
       RoleManager<IdentityRole> roleManager)

        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };

                var roleUser = new IdentityRole
                {
                    Name = "user",
                    NormalizedName = "user"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
                // создать роль user
                await roleManager.CreateAsync(roleUser);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // назначить роль user
                user = await userManager.FindByEmailAsync("user@mail.ru");
                await userManager.AddToRoleAsync(user, "user");

                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                
                await userManager.CreateAsync(admin, "123456");

                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }


            if (!context.Columns.Any())
            {
                context.AddRange(
                    new List<Column>
                    {
                        new Column { Name="1030-5708", Diametr=63, Height=260,HeightDepth=90},
                        new Column { Name="1030-5711", Diametr=63, Height=280,HeightDepth=90},
                        new Column { Name="1030-5713", Diametr=63, Height=300,HeightDepth=90},
                        new Column { Name="1030-5715", Diametr=63, Height=320,HeightDepth=90},
                        new Column { Name="1030-5717", Diametr=63, Height=340,HeightDepth=90},
                        new Column { Name="1030-5719", Diametr=63, Height=360,HeightDepth=90},
                        new Column { Name="1030-5722", Diametr=63, Height=380,HeightDepth=90},
                        new Column { Name="1030-5724", Diametr=63, Height=400,HeightDepth=90},
                        /////////////////////////////////////////////////////////////////////
                        new Column { Name="1030-5751", Diametr=71, Height=300,HeightDepth=110},
                        new Column { Name="1030-5753", Diametr=71, Height=320,HeightDepth=110},
                        new Column { Name="1030-5755", Diametr=71, Height=340,HeightDepth=110},
                        new Column { Name="1030-5759", Diametr=71, Height=380,HeightDepth=110},
                        new Column { Name="1030-5762", Diametr=71, Height=400,HeightDepth=110},
                        new Column { Name="1030-5764", Diametr=71, Height=420,HeightDepth=110},

                    });

                await context.SaveChangesAsync();
            }

            if (!context.Bushings.Any())
            {
                context.AddRange(
                new List<Bushing>
                {
                    new Bushing { Name="1032-3216", PressedDiametr=85, FlangeDiametr=90,ColumnDiametr=63,TotalHeight=125, DepthHeight=64},
                    new Bushing { Name="1032-3217", PressedDiametr=85, FlangeDiametr=90,ColumnDiametr=63,TotalHeight=125, DepthHeight=71},
                    new Bushing { Name="1032-3218", PressedDiametr=85, FlangeDiametr=90,ColumnDiametr=63,TotalHeight=125, DepthHeight=80},
                    new Bushing { Name="1032-3224", PressedDiametr=85, FlangeDiametr=90,ColumnDiametr=63,TotalHeight=140, DepthHeight=80},
                    new Bushing { Name="1032-3225", PressedDiametr=85, FlangeDiametr=90,ColumnDiametr=63,TotalHeight=140, DepthHeight=90},
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    new Bushing { Name="1032-3333", PressedDiametr=95, FlangeDiametr=100,ColumnDiametr=71,TotalHeight=125, DepthHeight=90},
                    new Bushing { Name="1032-3336", PressedDiametr=95, FlangeDiametr=100,ColumnDiametr=71,TotalHeight=140, DepthHeight=90},
                    new Bushing { Name="1032-3338", PressedDiametr=95, FlangeDiametr=100,ColumnDiametr=71,TotalHeight=160, DepthHeight=80}
                    

            });
                await context.SaveChangesAsync();
            }

            if (!context.Springs.Any())
            {
                context.AddRange(
                    new List<Spring>
                    {
                        new Spring{Name="1086-4060", Pspring=4.4,Diametr=32,Tmin=1,Tmax=2,Stroke=8, LengthScrew=52},
                        new Spring{Name="1086-4061", Pspring=4.4,Diametr=32,Tmin=2,Tmax=4,Stroke=10,LengthScrew=62},
                        new Spring{Name="1086-4062", Pspring=4.4,Diametr=32,Tmin=4,Tmax=6,Stroke=12,LengthScrew=72},
                        new Spring{Name="1086-4063", Pspring=4.4,Diametr=32,Tmin=6,Tmax=10,Stroke=16,LengthScrew=97},
                        new Spring{Name="1086-4064", Pspring=4.4,Diametr=32,Tmin=10,Tmax=14,Stroke=20,LengthScrew=121},
                        ///////////////////////////////////////////////////////////////////////////////////////////////
                        new Spring{Name="1086-4090", Pspring=7.75,Diametr=55,Tmin=1,Tmax=2,Stroke=8,LengthScrew=53},
                        new Spring{Name="1086-4091", Pspring=7.75,Diametr=55,Tmin=2,Tmax=4,Stroke=10,LengthScrew=67},
                        new Spring{Name="1086-4092", Pspring=7.75,Diametr=55,Tmin=4,Tmax=6,Stroke=12,LengthScrew=75},
                        new Spring{Name="1086-4093", Pspring=7.75,Diametr=55,Tmin=6,Tmax=10,Stroke=16,LengthScrew=97},
                        new Spring{Name="1086-4094", Pspring=7.75,Diametr=55,Tmin=10,Tmax=14,Stroke=20,LengthScrew=119},
                        new Spring{Name="1086-4095", Pspring=7.75,Diametr=55,Tmin=10,Tmax=14,Stroke=24,LengthScrew=141}

                    });

                await context.SaveChangesAsync();

            }   
            
            if(!context.Punches.Any())
            {
                context.AddRange(
                    new List<Punch>
                    {
                       new Punch{Name="1141-3796",DiametrHole=5,DiametrSeat=10,DiametrFlange=14,HeightTottal=63,HeighSeat=25,HeighFlange=6,HeightHole=18},
                       new Punch{Name="1141-3803",DiametrHole=5,DiametrSeat=10,DiametrFlange=14,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=18},
                       new Punch{Name="1141-3809",DiametrHole=5,DiametrSeat=10,DiametrFlange=14,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-3818",DiametrHole=5,DiametrSeat=10,DiametrFlange=14,HeightTottal=75,HeighSeat=32,HeighFlange=8,HeightHole=20},
                       new Punch{Name="1141-3825",DiametrHole=5,DiametrSeat=10,DiametrFlange=14,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-3832",DiametrHole=5,DiametrSeat=10,DiametrFlange=14,HeightTottal=85,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-3838",DiametrHole=5,DiametrSeat=10,DiametrFlange=14,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-3845",DiametrHole=5,DiametrSeat=10,DiametrFlange=14,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-3863",DiametrHole=6,DiametrSeat=12,DiametrFlange=16,HeightTottal=63,HeighSeat=25,HeighFlange=6,HeightHole=18},
                       new Punch{Name="1141-3869",DiametrHole=6,DiametrSeat=12,DiametrFlange=16,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=18},
                       new Punch{Name="1141-3876",DiametrHole=6,DiametrSeat=12,DiametrFlange=16,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-3885",DiametrHole=6,DiametrSeat=12,DiametrFlange=16,HeightTottal=75,HeighSeat=32,HeighFlange=8,HeightHole=20},
                       new Punch{Name="1141-3892",DiametrHole=6,DiametrSeat=12,DiametrFlange=16,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-3898",DiametrHole=6,DiametrSeat=12,DiametrFlange=16,HeightTottal=85,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-3905",DiametrHole=6,DiametrSeat=12,DiametrFlange=16,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-3912",DiametrHole=6,DiametrSeat=12,DiametrFlange=16,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-3925",DiametrHole=7,DiametrSeat=12,DiametrFlange=16,HeightTottal=63,HeighSeat=25,HeighFlange=6,HeightHole=18},
                       new Punch{Name="1141-3935",DiametrHole=7,DiametrSeat=12,DiametrFlange=16,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=18},
                       new Punch{Name="1141-3943",DiametrHole=7,DiametrSeat=12,DiametrFlange=16,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-3949",DiametrHole=7,DiametrSeat=12,DiametrFlange=16,HeightTottal=75,HeighSeat=32,HeighFlange=8,HeightHole=20},
                       new Punch{Name="1141-3958",DiametrHole=7,DiametrSeat=12,DiametrFlange=16,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-3965",DiametrHole=7,DiametrSeat=12,DiametrFlange=16,HeightTottal=85,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-3972",DiametrHole=7,DiametrSeat=12,DiametrFlange=16,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-3974",DiametrHole=7,DiametrSeat=12,DiametrFlange=16,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-3996",DiametrHole=8,DiametrSeat=14,DiametrFlange=18,HeightTottal=63,HeighSeat=25,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4003",DiametrHole=8,DiametrSeat=14,DiametrFlange=18,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4009",DiametrHole=8,DiametrSeat=14,DiametrFlange=18,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22},
                       new Punch{Name="1141-4016",DiametrHole=8,DiametrSeat=14,DiametrFlange=18,HeightTottal=75,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-4025",DiametrHole=8,DiametrSeat=14,DiametrFlange=18,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4032",DiametrHole=8,DiametrSeat=14,DiametrFlange=18,HeightTottal=85,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4038",DiametrHole=8,DiametrSeat=14,DiametrFlange=18,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-4045",DiametrHole=8,DiametrSeat=14,DiametrFlange=18,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},
                       //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-4076",DiametrHole=9,DiametrSeat=14,DiametrFlange=18,HeightTottal=63,HeighSeat=25,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4083",DiametrHole=9,DiametrSeat=14,DiametrFlange=18,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4089",DiametrHole=9,DiametrSeat=14,DiametrFlange=18,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22},
                       new Punch{Name="1141-4096",DiametrHole=9,DiametrSeat=14,DiametrFlange=18,HeightTottal=75,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-4105",DiametrHole=9,DiametrSeat=14,DiametrFlange=18,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4112",DiametrHole=9,DiametrSeat=14,DiametrFlange=18,HeightTottal=85,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4118",DiametrHole=9,DiametrSeat=14,DiametrFlange=18,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-4125",DiametrHole=9,DiametrSeat=14,DiametrFlange=18,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},
                       /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-4156",DiametrHole=10,DiametrSeat=16,DiametrFlange=20,HeightTottal=63,HeighSeat=25,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4163",DiametrHole=10,DiametrSeat=16,DiametrFlange=20,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4169",DiametrHole=10,DiametrSeat=16,DiametrFlange=20,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22},
                       new Punch{Name="1141-4176",DiametrHole=10,DiametrSeat=16,DiametrFlange=20,HeightTottal=75,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-4183",DiametrHole=10,DiametrSeat=16,DiametrFlange=20,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4192",DiametrHole=10,DiametrSeat=16,DiametrFlange=20,HeightTottal=85,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4198",DiametrHole=10,DiametrSeat=16,DiametrFlange=20,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-4235",DiametrHole=10,DiametrSeat=16,DiametrFlange=20,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},
                       ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-4236",DiametrHole=11,DiametrSeat=16,DiametrFlange=20,HeightTottal=63,HeighSeat=25,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4243",DiametrHole=11,DiametrSeat=16,DiametrFlange=20,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4249",DiametrHole=11,DiametrSeat=16,DiametrFlange=20,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22},
                       new Punch{Name="1141-4256",DiametrHole=11,DiametrSeat=16,DiametrFlange=20,HeightTottal=75,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-4263",DiametrHole=11,DiametrSeat=16,DiametrFlange=20,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4272",DiametrHole=11,DiametrSeat=16,DiametrFlange=20,HeightTottal=85,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4278",DiametrHole=11,DiametrSeat=16,DiametrFlange=20,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-4285",DiametrHole=11,DiametrSeat=16,DiametrFlange=20,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},
                       ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-4316",DiametrHole=12,DiametrSeat=18,DiametrFlange=22,HeightTottal=63,HeighSeat=25,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4323",DiametrHole=12,DiametrSeat=18,DiametrFlange=22,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4329",DiametrHole=12,DiametrSeat=18,DiametrFlange=22,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22},
                       new Punch{Name="1141-4336",DiametrHole=12,DiametrSeat=18,DiametrFlange=22,HeightTottal=75,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-4343",DiametrHole=12,DiametrSeat=18,DiametrFlange=22,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4349",DiametrHole=12,DiametrSeat=18,DiametrFlange=22,HeightTottal=85,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4358",DiametrHole=12,DiametrSeat=18,DiametrFlange=22,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-4365",DiametrHole=12,DiametrSeat=18,DiametrFlange=22,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},
                       /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-4396",DiametrHole=13,DiametrSeat=18,DiametrFlange=22,HeightTottal=63,HeighSeat=25,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4403",DiametrHole=13,DiametrSeat=18,DiametrFlange=22,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4409",DiametrHole=13,DiametrSeat=18,DiametrFlange=22,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22},
                       new Punch{Name="1141-4416",DiametrHole=13,DiametrSeat=18,DiametrFlange=22,HeightTottal=75,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-4423",DiametrHole=13,DiametrSeat=18,DiametrFlange=22,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4429",DiametrHole=13,DiametrSeat=18,DiametrFlange=22,HeightTottal=85,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4438",DiametrHole=13,DiametrSeat=18,DiametrFlange=22,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-4445",DiametrHole=13,DiametrSeat=18,DiametrFlange=22,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},
                       ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-4476",DiametrHole=14,DiametrSeat=20,DiametrFlange=24,HeightTottal=63,HeighSeat=25,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4483",DiametrHole=14,DiametrSeat=20,DiametrFlange=24,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4489",DiametrHole=14,DiametrSeat=20,DiametrFlange=24,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22},
                       new Punch{Name="1141-4496",DiametrHole=14,DiametrSeat=20,DiametrFlange=24,HeightTottal=75,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-4503",DiametrHole=14,DiametrSeat=20,DiametrFlange=24,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4509",DiametrHole=14,DiametrSeat=20,DiametrFlange=24,HeightTottal=85,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4516",DiametrHole=14,DiametrSeat=20,DiametrFlange=24,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-4523",DiametrHole=14,DiametrSeat=20,DiametrFlange=24,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},
                       ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-4556",DiametrHole=15,DiametrSeat=20,DiametrFlange=24,HeightTottal=63,HeighSeat=25,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4563",DiametrHole=15,DiametrSeat=20,DiametrFlange=24,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4569",DiametrHole=15,DiametrSeat=20,DiametrFlange=24,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22},
                       new Punch{Name="1141-4576",DiametrHole=15,DiametrSeat=20,DiametrFlange=24,HeightTottal=75,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-4583",DiametrHole=15,DiametrSeat=20,DiametrFlange=24,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4589",DiametrHole=15,DiametrSeat=20,DiametrFlange=24,HeightTottal=85,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4596",DiametrHole=15,DiametrSeat=20,DiametrFlange=24,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-4603",DiametrHole=15,DiametrSeat=20,DiametrFlange=24,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},
                       ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-4636",DiametrHole=16,DiametrSeat=22,DiametrFlange=26,HeightTottal=63,HeighSeat=25,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4643",DiametrHole=16,DiametrSeat=22,DiametrFlange=26,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4649",DiametrHole=16,DiametrSeat=22,DiametrFlange=26,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22},
                       new Punch{Name="1141-4656",DiametrHole=16,DiametrSeat=22,DiametrFlange=26,HeightTottal=75,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-4663",DiametrHole=16,DiametrSeat=22,DiametrFlange=26,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4669",DiametrHole=16,DiametrSeat=22,DiametrFlange=26,HeightTottal=85,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4676",DiametrHole=16,DiametrSeat=22,DiametrFlange=26,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-4683",DiametrHole=16,DiametrSeat=22,DiametrFlange=26,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},
                       ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-4718",DiametrHole=17,DiametrSeat=22,DiametrFlange=26,HeightTottal=63,HeighSeat=25,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4723",DiametrHole=17,DiametrSeat=22,DiametrFlange=26,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4729",DiametrHole=17,DiametrSeat=22,DiametrFlange=26,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22},
                       new Punch{Name="1141-4736",DiametrHole=17,DiametrSeat=22,DiametrFlange=26,HeightTottal=75,HeighSeat=32,HeighFlange=8,HeightHole=22},
                       new Punch{Name="1141-4743",DiametrHole=17,DiametrSeat=22,DiametrFlange=26,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4749",DiametrHole=17,DiametrSeat=22,DiametrFlange=26,HeightTottal=85,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4756",DiametrHole=17,DiametrSeat=22,DiametrFlange=26,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-4763",DiametrHole=17,DiametrSeat=22,DiametrFlange=26,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},
                       //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                      
                       new Punch{Name="1141-4803",DiametrHole=18,DiametrSeat=25,DiametrFlange=30,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4809",DiametrHole=18,DiametrSeat=25,DiametrFlange=30,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22}, 
                       new Punch{Name="1141-4823",DiametrHole=18,DiametrSeat=25,DiametrFlange=30,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},                    
                       new Punch{Name="1141-4836",DiametrHole=18,DiametrSeat=25,DiametrFlange=30,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-4843",DiametrHole=18,DiametrSeat=25,DiametrFlange=30,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},
                       ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-4883",DiametrHole=19,DiametrSeat=25,DiametrFlange=30,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4889",DiametrHole=19,DiametrSeat=25,DiametrFlange=30,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22},
                       new Punch{Name="1141-4903",DiametrHole=19,DiametrSeat=25,DiametrFlange=30,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4916",DiametrHole=19,DiametrSeat=25,DiametrFlange=30,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-4923",DiametrHole=19,DiametrSeat=25,DiametrFlange=30,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},
                       /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-4963",DiametrHole=20,DiametrSeat=25,DiametrFlange=30,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-4969",DiametrHole=20,DiametrSeat=25,DiametrFlange=30,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22},
                       new Punch{Name="1141-4983",DiametrHole=20,DiametrSeat=25,DiametrFlange=30,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-4996",DiametrHole=20,DiametrSeat=25,DiametrFlange=30,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-5003",DiametrHole=20,DiametrSeat=25,DiametrFlange=30,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},
                       //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-5043",DiametrHole=21,DiametrSeat=28,DiametrFlange=32,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-5049",DiametrHole=21,DiametrSeat=28,DiametrFlange=32,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22},
                       new Punch{Name="1141-5063",DiametrHole=21,DiametrSeat=28,DiametrFlange=32,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-5076",DiametrHole=21,DiametrSeat=28,DiametrFlange=32,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-5083",DiametrHole=21,DiametrSeat=28,DiametrFlange=32,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},
                       ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-5123",DiametrHole=22,DiametrSeat=28,DiametrFlange=32,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-5129",DiametrHole=22,DiametrSeat=28,DiametrFlange=32,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22},
                       new Punch{Name="1141-5143",DiametrHole=22,DiametrSeat=28,DiametrFlange=32,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-5156",DiametrHole=22,DiametrSeat=28,DiametrFlange=32,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-5163",DiametrHole=22,DiametrSeat=28,DiametrFlange=32,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},
                       /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new Punch{Name="1141-5123",DiametrHole=23,DiametrSeat=28,DiametrFlange=32,HeightTottal=67,HeighSeat=28,HeighFlange=6,HeightHole=20},
                       new Punch{Name="1141-5129",DiametrHole=23,DiametrSeat=28,DiametrFlange=32,HeightTottal=71,HeighSeat=28,HeighFlange=6,HeightHole=22},
                       new Punch{Name="1141-5143",DiametrHole=23,DiametrSeat=28,DiametrFlange=32,HeightTottal=80,HeighSeat=32,HeighFlange=8,HeightHole=25},
                       new Punch{Name="1141-5156",DiametrHole=23,DiametrSeat=28,DiametrFlange=32,HeightTottal=90,HeighSeat=36,HeighFlange=8,HeightHole=28},
                       new Punch{Name="1141-5163",DiametrHole=23,DiametrSeat=28,DiametrFlange=32,HeightTottal=100,HeighSeat=36,HeighFlange=8,HeightHole=32},

                    });

                await context.SaveChangesAsync();
            }
            if (!context.EnlargedPunches.Any())
            {
                context.AddRange(new List<EnlargedPunch>
                {
                       new EnlargedPunch{Name="1141-5725",DiametrHoleFirst=24,DiametrHoleLast=26,DiametrSeat=28,DiametrFlange=32,HeightTottal=63,HeighSeat=25,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5727",DiametrHoleFirst=24,DiametrHoleLast=26,DiametrSeat=28,DiametrFlange=32,HeightTottal=67,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5729",DiametrHoleFirst=24,DiametrHoleLast=26,DiametrSeat=28,DiametrFlange=32,HeightTottal=71,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5732",DiametrHoleFirst=24,DiametrHoleLast=26,DiametrSeat=28,DiametrFlange=32,HeightTottal=75,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5734",DiametrHoleFirst=24,DiametrHoleLast=26,DiametrSeat=28,DiametrFlange=32,HeightTottal=80,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5736",DiametrHoleFirst=24,DiametrHoleLast=26,DiametrSeat=28,DiametrFlange=32,HeightTottal=85,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5738",DiametrHoleFirst=24,DiametrHoleLast=26,DiametrSeat=28,DiametrFlange=32,HeightTottal=90,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5741",DiametrHoleFirst=24,DiametrHoleLast=26,DiametrSeat=28,DiametrFlange=32,HeightTottal=95,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5743",DiametrHoleFirst=24,DiametrHoleLast=26,DiametrSeat=28,DiametrFlange=32,HeightTottal=100,HeighSeat=36,HeighFlange=8},
                       ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new EnlargedPunch{Name="1141-5754",DiametrHoleFirst=26,DiametrHoleLast=28,DiametrSeat=32,DiametrFlange=36,HeightTottal=63,HeighSeat=25,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5756",DiametrHoleFirst=26,DiametrHoleLast=28,DiametrSeat=32,DiametrFlange=36,HeightTottal=67,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5758",DiametrHoleFirst=26,DiametrHoleLast=28,DiametrSeat=32,DiametrFlange=36,HeightTottal=71,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5761",DiametrHoleFirst=26,DiametrHoleLast=28,DiametrSeat=32,DiametrFlange=36,HeightTottal=75,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5763",DiametrHoleFirst=26,DiametrHoleLast=28,DiametrSeat=32,DiametrFlange=36,HeightTottal=80,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5765",DiametrHoleFirst=26,DiametrHoleLast=28,DiametrSeat=32,DiametrFlange=36,HeightTottal=85,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5767",DiametrHoleFirst=26,DiametrHoleLast=28,DiametrSeat=32,DiametrFlange=36,HeightTottal=90,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5769",DiametrHoleFirst=26,DiametrHoleLast=28,DiametrSeat=32,DiametrFlange=36,HeightTottal=95,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5772",DiametrHoleFirst=26,DiametrHoleLast=28,DiametrSeat=32,DiametrFlange=36,HeightTottal=100,HeighSeat=36,HeighFlange=8},
                       /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new EnlargedPunch{Name="1141-5783",DiametrHoleFirst=28,DiametrHoleLast=30,DiametrSeat=28,DiametrFlange=32,HeightTottal=63,HeighSeat=25,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5786",DiametrHoleFirst=28,DiametrHoleLast=30,DiametrSeat=28,DiametrFlange=32,HeightTottal=67,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5787",DiametrHoleFirst=28,DiametrHoleLast=30,DiametrSeat=28,DiametrFlange=32,HeightTottal=71,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5789",DiametrHoleFirst=28,DiametrHoleLast=30,DiametrSeat=28,DiametrFlange=32,HeightTottal=75,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5792",DiametrHoleFirst=28,DiametrHoleLast=30,DiametrSeat=28,DiametrFlange=32,HeightTottal=80,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5794",DiametrHoleFirst=28,DiametrHoleLast=30,DiametrSeat=28,DiametrFlange=32,HeightTottal=85,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5796",DiametrHoleFirst=28,DiametrHoleLast=30,DiametrSeat=28,DiametrFlange=32,HeightTottal=90,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5798",DiametrHoleFirst=28,DiametrHoleLast=30,DiametrSeat=28,DiametrFlange=32,HeightTottal=95,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5801",DiametrHoleFirst=28,DiametrHoleLast=30,DiametrSeat=28,DiametrFlange=32,HeightTottal=100,HeighSeat=36,HeighFlange=8},
                       ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new EnlargedPunch{Name="1141-5812",DiametrHoleFirst=30,DiametrHoleLast=32,DiametrSeat=36,DiametrFlange=40,HeightTottal=63,HeighSeat=25,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5814",DiametrHoleFirst=30,DiametrHoleLast=32,DiametrSeat=36,DiametrFlange=40,HeightTottal=67,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5816",DiametrHoleFirst=30,DiametrHoleLast=32,DiametrSeat=36,DiametrFlange=40,HeightTottal=71,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5818",DiametrHoleFirst=30,DiametrHoleLast=32,DiametrSeat=36,DiametrFlange=40,HeightTottal=75,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5820",DiametrHoleFirst=30,DiametrHoleLast=32,DiametrSeat=36,DiametrFlange=40,HeightTottal=80,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5822",DiametrHoleFirst=30,DiametrHoleLast=32,DiametrSeat=36,DiametrFlange=40,HeightTottal=85,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5824",DiametrHoleFirst=30,DiametrHoleLast=32,DiametrSeat=36,DiametrFlange=40,HeightTottal=90,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5826",DiametrHoleFirst=30,DiametrHoleLast=32,DiametrSeat=36,DiametrFlange=40,HeightTottal=95,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5828",DiametrHoleFirst=30,DiametrHoleLast=32,DiametrSeat=36,DiametrFlange=40,HeightTottal=100,HeighSeat=36,HeighFlange=8},
                       ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new EnlargedPunch{Name="1141-5839",DiametrHoleFirst=32,DiametrHoleLast=34,DiametrSeat=36,DiametrFlange=40,HeightTottal=63,HeighSeat=25,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5842",DiametrHoleFirst=32,DiametrHoleLast=34,DiametrSeat=36,DiametrFlange=40,HeightTottal=67,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5844",DiametrHoleFirst=32,DiametrHoleLast=34,DiametrSeat=36,DiametrFlange=40,HeightTottal=71,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5846",DiametrHoleFirst=32,DiametrHoleLast=34,DiametrSeat=36,DiametrFlange=40,HeightTottal=75,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5848",DiametrHoleFirst=32,DiametrHoleLast=34,DiametrSeat=36,DiametrFlange=40,HeightTottal=80,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5851",DiametrHoleFirst=32,DiametrHoleLast=34,DiametrSeat=36,DiametrFlange=40,HeightTottal=85,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5853",DiametrHoleFirst=32,DiametrHoleLast=34,DiametrSeat=36,DiametrFlange=40,HeightTottal=90,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5855",DiametrHoleFirst=32,DiametrHoleLast=34,DiametrSeat=36,DiametrFlange=40,HeightTottal=95,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5867",DiametrHoleFirst=32,DiametrHoleLast=34,DiametrSeat=36,DiametrFlange=40,HeightTottal=100,HeighSeat=36,HeighFlange=8},
                       ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new EnlargedPunch{Name="1141-5868",DiametrHoleFirst=34,DiametrHoleLast=36,DiametrSeat=40,DiametrFlange=45,HeightTottal=63,HeighSeat=25,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5871",DiametrHoleFirst=34,DiametrHoleLast=36,DiametrSeat=40,DiametrFlange=45,HeightTottal=67,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5873",DiametrHoleFirst=34,DiametrHoleLast=36,DiametrSeat=40,DiametrFlange=45,HeightTottal=71,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5875",DiametrHoleFirst=34,DiametrHoleLast=36,DiametrSeat=40,DiametrFlange=45,HeightTottal=75,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5877",DiametrHoleFirst=34,DiametrHoleLast=36,DiametrSeat=40,DiametrFlange=45,HeightTottal=80,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5879",DiametrHoleFirst=34,DiametrHoleLast=36,DiametrSeat=40,DiametrFlange=45,HeightTottal=85,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5882",DiametrHoleFirst=34,DiametrHoleLast=36,DiametrSeat=40,DiametrFlange=45,HeightTottal=90,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5884",DiametrHoleFirst=34,DiametrHoleLast=36,DiametrSeat=40,DiametrFlange=45,HeightTottal=95,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5866",DiametrHoleFirst=34,DiametrHoleLast=36,DiametrSeat=40,DiametrFlange=45,HeightTottal=100,HeighSeat=36,HeighFlange=8},
                       ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new EnlargedPunch{Name="1141-5897",DiametrHoleFirst=36,DiametrHoleLast=38,DiametrSeat=40,DiametrFlange=45,HeightTottal=63,HeighSeat=25,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5899",DiametrHoleFirst=36,DiametrHoleLast=38,DiametrSeat=40,DiametrFlange=45,HeightTottal=67,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5902",DiametrHoleFirst=36,DiametrHoleLast=38,DiametrSeat=40,DiametrFlange=45,HeightTottal=71,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5904",DiametrHoleFirst=36,DiametrHoleLast=38,DiametrSeat=40,DiametrFlange=45,HeightTottal=75,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5906",DiametrHoleFirst=36,DiametrHoleLast=38,DiametrSeat=40,DiametrFlange=45,HeightTottal=80,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5908",DiametrHoleFirst=36,DiametrHoleLast=38,DiametrSeat=40,DiametrFlange=45,HeightTottal=85,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5911",DiametrHoleFirst=36,DiametrHoleLast=38,DiametrSeat=40,DiametrFlange=45,HeightTottal=90,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5913",DiametrHoleFirst=36,DiametrHoleLast=38,DiametrSeat=40,DiametrFlange=45,HeightTottal=95,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5915",DiametrHoleFirst=36,DiametrHoleLast=38,DiametrSeat=40,DiametrFlange=45,HeightTottal=100,HeighSeat=36,HeighFlange=8},
                       /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new EnlargedPunch{Name="1141-5926",DiametrHoleFirst=38,DiametrHoleLast=44,DiametrSeat=45,DiametrFlange=50,HeightTottal=63,HeighSeat=25,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5928",DiametrHoleFirst=38,DiametrHoleLast=44,DiametrSeat=45,DiametrFlange=50,HeightTottal=67,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5931",DiametrHoleFirst=38,DiametrHoleLast=44,DiametrSeat=45,DiametrFlange=50,HeightTottal=71,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-5933",DiametrHoleFirst=38,DiametrHoleLast=44,DiametrSeat=45,DiametrFlange=50,HeightTottal=75,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5935",DiametrHoleFirst=38,DiametrHoleLast=44,DiametrSeat=45,DiametrFlange=50,HeightTottal=80,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5937",DiametrHoleFirst=38,DiametrHoleLast=44,DiametrSeat=45,DiametrFlange=50,HeightTottal=85,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5939",DiametrHoleFirst=38,DiametrHoleLast=44,DiametrSeat=45,DiametrFlange=50,HeightTottal=90,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5942",DiametrHoleFirst=38,DiametrHoleLast=44,DiametrSeat=45,DiametrFlange=50,HeightTottal=95,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-5944",DiametrHoleFirst=38,DiametrHoleLast=44,DiametrSeat=45,DiametrFlange=50,HeightTottal=100,HeighSeat=36,HeighFlange=8},
                       ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new EnlargedPunch{Name="1141-6013",DiametrHoleFirst=44,DiametrHoleLast=48,DiametrSeat=50,DiametrFlange=55,HeightTottal=63,HeighSeat=25,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-6015",DiametrHoleFirst=44,DiametrHoleLast=48,DiametrSeat=50,DiametrFlange=55,HeightTottal=67,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-6017",DiametrHoleFirst=44,DiametrHoleLast=48,DiametrSeat=50,DiametrFlange=55,HeightTottal=71,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-6019",DiametrHoleFirst=44,DiametrHoleLast=48,DiametrSeat=50,DiametrFlange=55,HeightTottal=75,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-6022",DiametrHoleFirst=44,DiametrHoleLast=48,DiametrSeat=50,DiametrFlange=55,HeightTottal=80,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-6024",DiametrHoleFirst=44,DiametrHoleLast=48,DiametrSeat=50,DiametrFlange=55,HeightTottal=85,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-6025",DiametrHoleFirst=44,DiametrHoleLast=48,DiametrSeat=50,DiametrFlange=55,HeightTottal=90,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-6028",DiametrHoleFirst=44,DiametrHoleLast=48,DiametrSeat=50,DiametrFlange=55,HeightTottal=95,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-6031",DiametrHoleFirst=44,DiametrHoleLast=48,DiametrSeat=50,DiametrFlange=55,HeightTottal=100,HeighSeat=36,HeighFlange=8},
                       ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       new EnlargedPunch{Name="1141-6071",DiametrHoleFirst=48,DiametrHoleLast=52,DiametrSeat=56,DiametrFlange=60,HeightTottal=63,HeighSeat=25,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-6073",DiametrHoleFirst=48,DiametrHoleLast=52,DiametrSeat=56,DiametrFlange=60,HeightTottal=67,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-6075",DiametrHoleFirst=48,DiametrHoleLast=52,DiametrSeat=56,DiametrFlange=60,HeightTottal=71,HeighSeat=28,HeighFlange=6,},
                       new EnlargedPunch{Name="1141-6077",DiametrHoleFirst=48,DiametrHoleLast=52,DiametrSeat=56,DiametrFlange=60,HeightTottal=75,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-6079",DiametrHoleFirst=48,DiametrHoleLast=52,DiametrSeat=56,DiametrFlange=60,HeightTottal=80,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-6082",DiametrHoleFirst=48,DiametrHoleLast=52,DiametrSeat=56,DiametrFlange=60,HeightTottal=85,HeighSeat=32,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-6084",DiametrHoleFirst=48,DiametrHoleLast=52,DiametrSeat=56,DiametrFlange=60,HeightTottal=90,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-6086",DiametrHoleFirst=48,DiametrHoleLast=52,DiametrSeat=56,DiametrFlange=60,HeightTottal=95,HeighSeat=36,HeighFlange=8,},
                       new EnlargedPunch{Name="1141-6088",DiametrHoleFirst=48,DiametrHoleLast=52,DiametrSeat=56,DiametrFlange=60,HeightTottal=100,HeighSeat=36,HeighFlange=8}
                });
                await context.SaveChangesAsync();
            }


            if (!context.Covers.Any())
            {
                context.AddRange(
                    new List<Cover>
                    {
                        new Cover{Name="1081-0147", Diametr=140, TotalHeight=191, PressHeight=125 },
                        new Cover{Name="1081-0148", Diametr=140, TotalHeight=262, PressHeight=125 },
                        new Cover{Name="1081-0149", Diametr=140, TotalHeight=323, PressHeight=125 },
                        new Cover{Name="1081-0151", Diametr=156, TotalHeight=382, PressHeight=165 },
                        new Cover{Name="1081-0152", Diametr=156, TotalHeight=483, PressHeight=165 },
                        new Cover{Name="1081-0153", Diametr=156, TotalHeight=574, PressHeight=165 },


                    });

                await context.SaveChangesAsync();

            }



            if (!context.Pressess.Any())
            {
                context.AddRange(
                    new List<Press>
                    {
                        new Press{Name="KA2036", Ppress=4000, PressRamStroke=320, LengthAdapt=800,WidthAdapt=700 },
                        new Press{Name="PKZ500", Ppress=5000, PressRamStroke=400, LengthAdapt=900,WidthAdapt=800 },
                        new Press{Name="KB3539", Ppress=5500, PressRamStroke=420, LengthAdapt=1000,WidthAdapt=900 },
                        new Press{Name="K2538", Ppress=6000, PressRamStroke=450, LengthAdapt=1200,WidthAdapt=1100 },
                        new Press{Name="KB2542", Ppress=6500, PressRamStroke=420, LengthAdapt=1300,WidthAdapt=1200 },
                        new Press{Name="KA3040", Ppress=7000, PressRamStroke=400, LengthAdapt=1400,WidthAdapt=1300 },
                        new Press{Name="DE315", Ppress=7500, PressRamStroke=400, LengthAdapt=1500,WidthAdapt=1400 },


                    });

                await context.SaveChangesAsync();

            }




        }
            


        }

    
}
