Feature: Getir

@Case1
Scenario: Product add basket then check and delete
	Given I pass onboarding screens click skip button
	And I check that I am at home page
	Then I change category to water
	And I see product list in "Water" page
	And I open "1" indexed product detail
	And I add this product to basket 
	Then I go to basket and checks added product and price
	When I delete products from basket
	Then I check is basket empty

@Case2
Scenario: Check product price on detail page
	Given I pass onboarding screens click skip button
	And I check that I am at home page
	Then I open the left menu
	And I go to "Baby Care" category
	And I open "3" indexed product detail
	Then I check that the product price is equal to "$1,98"
	And I back to category detail page
	Then I see product list in "Baby Care" page
