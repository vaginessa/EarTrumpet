﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EarTrumpet.DataModel;

namespace EarTrumpet_Actions.DataModel
{
    public class Device
    {
        public static ObservableCollection<Option> AllDevices
        {
            get
            {
                var ret = new ObservableCollection<Option>();
                ret.Add(new Option("Default playback device", null));
                foreach (var device in DataModelFactory.CreateAudioDeviceManager(AudioDeviceKind.Playback).Devices)
                {
                    ret.Add(new Option(device.DisplayName, new Device(device)));
                }
                return ret;
            }
        }

        public Device()
        {

        }

        public Device(IAudioDevice device)
        {
            Id = device.Id;
        }

        public string Id { get; set; }

        public override string ToString()
        {
            if (Id == null)
            {
                return "Default playback device";
            }

            var device = DataModelFactory.CreateAudioDeviceManager(AudioDeviceKind.Playback).Devices.FirstOrDefault(d => d.Id == Id);
            if (device != null)
            {
                return device.DisplayName;
            }
            return Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
