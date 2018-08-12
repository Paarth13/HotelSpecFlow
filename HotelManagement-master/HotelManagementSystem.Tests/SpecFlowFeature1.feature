Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And Use has added required details for hotel
	When User calls AddHotel api
	Then Hotel with name '<name>' should be present in the response
Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |


@GetHotelById
Scenario Outline: User Adds a hotel and searches for it.
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api
	When User provides a valid Id '<id>' for hotel 
	Then Hotel with id '<id>' should be present in the response
Examples: 
| id | name   |
| 4  | hotel4 |

@GetAllHotels
Scenario: User checks whether the list has been updated or not.
	Given User provided valid Id '7'  and 'Hyatt'for hotel
	And Use has added required details for hotel
	And User calls AddHotel api
	Given User provided valid Id '8'  and 'Novotel'for hotel 
	And Use has added required details for hotel
	When User calls AddHotel api
	
	Then Hotel with id '7,8' should be present
					  

	
