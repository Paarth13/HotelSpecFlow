using FluentAssertions;
using HotelManagementSystem.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        private Hotel addHotelResponse;
        private List<Hotel> hotels = new List<Hotel>();
       // private List<Hotel> hotelsOriginal = new List<Hotel>();

        [Given(@"User provided valid Id '(.*)'  and '(.*)'for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
        }

        [Given(@"Use has added required details for hotel")]
        public void GivenUseHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }

        [When(@"User calls AddHotel api")]
        [Given(@"User calls AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {
            hotels = HotelsApiCaller.AddHotel(hotel);
        }

        [Then(@"Hotel with name '(.*)' should be present in the response")]
        public void ThenHotelWithNameShouldBePresentInTheResponse(string name)
        {
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response",name));
        }

        [When(@"User provides a valid Id '(.*)' for hotel")]
        public void GivenUserProvidesAValidIdForHotel(int id)
        {
            hotel = HotelsApiCaller.GetHotelsById(id);
        }

        [Then(@"Hotel with id '(.*)' should be present in the response")]
        public void ThenHotelWithIdShouldBePresentInTheResponse(int id)
        {
            hotel.Id.Should().Equals(id);
        }

        [Then(@"Hotel with id '(.*)' should be present")]
        public void ThenHotelWithIdShouldBePresent(string values)
        {
            var s = values.Split(',');
            foreach (string s1 in s )
            {
                var check = hotels.Find(ht => ht.Id==int.Parse(s1));
                check.Should().NotBeNull();
            }
        }



        private void SetHotelBasicDetails()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            hotel.Address = "Address1";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }
    }
}
