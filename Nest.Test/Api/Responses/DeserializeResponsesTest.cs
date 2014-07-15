using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nest.Api;
using Nest.Api.Responses;
using Newtonsoft.Json;

namespace Nest.Test.Api.Responses
{
    [TestClass]
    public class DeserializeResponsesTest
    {
        [TestMethod]
        public void Can_deserialize_thermostat_device()
        {
            const string json = @"
                {
                    ""locale"":""en-US"",
                    ""temperature_scale"":""F"",
                    ""is_using_emergency_heat"":true,
                    ""has_fan"":true,
                    ""software_version"":""4.2.4"",
                    ""has_leaf"":true,
                    ""device_id"":""Ou2E2DKsbwn9eoPxh_Dl-s44IV03tUsp"",
                    ""name"":""Living Room (Nest)"",
                    ""can_heat"":true,
                    ""can_cool"":true,
                    ""hvac_mode"":""cool"",
                    ""target_temperature_c"":26.5,
                    ""target_temperature_f"":80,
                    ""target_temperature_high_c"":24.0,
                    ""target_temperature_high_f"":75,
                    ""target_temperature_low_c"":20.0,
                    ""target_temperature_low_f"":68,
                    ""ambient_temperature_c"":25.5,
                    ""ambient_temperature_f"":79,
                    ""away_temperature_high_c"":29.0,
                    ""away_temperature_high_f"":85,
                    ""away_temperature_low_c"":15.5,
                    ""away_temperature_low_f"":60,
                    ""structure_id"":""I7NlghizVD5HsYNWhTS4pkySp-y9nn8mCsGbEb5uwn13u5vI4KBUNA"",
                    ""fan_timer_active"":true,
                    ""name_long"":""Living Room Thermostat (Nest)"",
                    ""is_online"":true,
                    ""last_connection"":""2014-07-15T17:33:06.552Z""
                }";

            Thermostat thermostat = JsonConvert.DeserializeObject<Thermostat>(json);
            Assert.AreEqual("en-US", thermostat.LocaleString);
            Assert.IsNotNull(thermostat.Locale);
            Assert.AreEqual("F", thermostat.TemperatureScaleString);
            Assert.AreEqual(TemperatureScale.Fahrenheit, thermostat.TemperatureScale);
            Assert.AreEqual(true, thermostat.IsUsingEmergencyHeat);
            Assert.AreEqual(true, thermostat.HasFan);
            Assert.AreEqual("4.2.4", thermostat.SoftwareVersion);
            Assert.AreEqual(true, thermostat.HasLeaf);
            Assert.AreEqual("Ou2E2DKsbwn9eoPxh_Dl-s44IV03tUsp", thermostat.DeviceId);
            Assert.AreEqual("Living Room (Nest)", thermostat.Name);
            Assert.AreEqual(true, thermostat.CanCool);
            Assert.AreEqual(true, thermostat.CanHeat);
            Assert.AreEqual("cool", thermostat.HvacModeString);
            Assert.AreEqual(HvacMode.Cool, thermostat.HvacMode);
            Assert.AreEqual(26.5, thermostat.TargetTemperatureCelsius);
            Assert.AreEqual(80, thermostat.TargetTemperatureFahrenheit);
            Assert.AreEqual(24.0, thermostat.TargetTemperatureHighCelsius);
            Assert.AreEqual(75, thermostat.TargetTemperatureHighFahrenheit);
            Assert.AreEqual(20.0, thermostat.TargetTemperatureLowCelsius);
            Assert.AreEqual(68, thermostat.TargetTemperatureLowFahrenheit);
            Assert.AreEqual(68, thermostat.TargetTemperatureLowFahrenheit);
            Assert.AreEqual(25.5, thermostat.AmbientTemperatureCelsius);
            Assert.AreEqual(79, thermostat.AmbientTemperatureFahrenheit);
            Assert.AreEqual(29.0, thermostat.AwayTemperatureHighCelsius);
            Assert.AreEqual(85, thermostat.AwayTemperatureHighFahrenheit);
            Assert.AreEqual(15.5, thermostat.AwayTemperatureLowCelsius);
            Assert.AreEqual(60, thermostat.AwayTemperatureLowFahrenheit);
            Assert.AreEqual("I7NlghizVD5HsYNWhTS4pkySp-y9nn8mCsGbEb5uwn13u5vI4KBUNA", thermostat.StructureId);
            Assert.AreEqual(true, thermostat.IsFanTimerActive);
            Assert.AreEqual("Living Room Thermostat (Nest)", thermostat.LongName);
            Assert.AreEqual(true, thermostat.IsOnline);
        }

        [TestMethod]
        public void Can_deserialize_co2_smoke_alarm_device()
        {
            const string json = @"
                {
                    ""device_id"": ""RTMTKxsQTCxzVcsySOHPxKoF4OyCifrs"" ,
                    ""locale"": ""en-US"" ,
                    ""software_version"": ""1.01"" ,
                    ""structure_id"": ""VqFabWH21nwVyd4RWgJgNb292wa7hG_dUwo2i2SG7j3-BOLY0BA4sw"" ,
                    ""name"": ""Hallway (upstairs)"" ,
                    ""name_long"": ""Hallway Protect (upstairs)"" ,
                    ""last_connection"": ""2014-03-02T23:20:19+00:00"" ,
                    ""is_online"": true ,
                    ""battery_health"": ""ok"" ,
                    ""co_alarm_state"": ""warning"" ,
                    ""smoke_alarm_state"": ""emergency"" ,
                    ""ui_color_state"": ""gray""
                }";
            SmokeCo2Alarm alarm = JsonConvert.DeserializeObject<SmokeCo2Alarm>(json);
            Assert.AreEqual("RTMTKxsQTCxzVcsySOHPxKoF4OyCifrs", alarm.DeviceId);
            Assert.AreEqual("en-US", alarm.LocaleString);
            Assert.IsNotNull(alarm.Locale);
            Assert.AreEqual("1.01", alarm.SoftwareVersion);
            Assert.AreEqual("VqFabWH21nwVyd4RWgJgNb292wa7hG_dUwo2i2SG7j3-BOLY0BA4sw", alarm.StructureId);
            Assert.AreEqual("Hallway (upstairs)", alarm.Name);
            Assert.AreEqual("Hallway Protect (upstairs)", alarm.LongName);
            Assert.AreEqual(true, alarm.IsOnline);
            Assert.AreEqual("ok", alarm.BatteryHealthString);
            Assert.AreEqual(BatteryHealth.OK, alarm.BatteryHealth);
            Assert.AreEqual("warning", alarm.CoAlarmStateString);
            Assert.AreEqual(AlarmState.Warning, alarm.CO2AlarmState);
            Assert.AreEqual("emergency", alarm.SmokeAlarmStateString);
            Assert.AreEqual(AlarmState.Emergency, alarm.SmokeAlarmState);
            Assert.AreEqual("gray", alarm.UiColorState);
        }

        [TestMethod]
        public void Can_deserialize_structure()
        {
            const string json = @"
                {
                    ""structure_id"": ""VqFabWH21nwVyd4RWgJgNb292wa7hG_dUwo2i2SG7j3-BOLY0BA4sw"" ,
                    ""thermostats"": [ ""peyiJNo0IldT2YlIVtYaGQ"", ""RTMTKxsQTCxzVcsySOHPxKoF4OyCirs"" ] ,
                    ""smoke_co_alarms"": [ ""RTMTKxsQTCxzVcsySOHPxKoF4OyCifrs"", ""RTMTKxsQTCxzVcsySOHPxKoF4OyCirs"" ] ,
                    ""away"": ""auto-away"" ,
                    ""name"": ""Home"" ,
                    ""country_code"": ""US"" ,
                    ""peak_period_start_time"": ""2014-03-10T23:10:12+00:00"" ,
                    ""peak_period_end_time"": ""2014-03-10T23:14:19+00:00"" ,
                    ""time_zone"": ""America/Los_Angeles"" ,
                    ""eta"": {
                        ""trip_id"": ""myTripHome1024"" ,
                        ""estimated_arrival_window_begin"": ""2014-07-04T10:48:11+00:00"" ,
                        ""estimated_arrival_window_end"": ""2014-07-04T18:48:11+00:00""
                    }
                }";
            Structure structure = JsonConvert.DeserializeObject<Structure>(json);
            Assert.AreEqual("VqFabWH21nwVyd4RWgJgNb292wa7hG_dUwo2i2SG7j3-BOLY0BA4sw", structure.StructureId);
            Assert.AreEqual(2, structure.Thermostats.Count());
            Assert.AreEqual(2, structure.SmokeCoAlarms.Count());
            Assert.AreEqual("auto-away", structure.AwayString);
            Assert.AreEqual(AwayState.AutoAway, structure.Away);
            Assert.AreEqual("Home", structure.Name);
            Assert.AreEqual("US", structure.CountryCode);
            Assert.AreEqual("America/Los_Angeles", structure.Timezone);
            Assert.IsNotNull(structure.Eta);
            Assert.AreEqual("myTripHome1024", structure.Eta.TripId);
        }
    }
}
