Feature: ProductDetails

Verifying product details and prices on the seacrh products page, on the product details page and on the checkout page.

@Positive
Scenario: Verify product name and price
	When I navigate to the home page
	Then assert that I see the Ebay logo
	When I select category <category> from the category filter dropdown
	And I search by keyword <keyword>
	And I press the Search button
	Then assert that the first result has <keyword> in the title
	And assert that the first result has <shippingType> shipping
	And assert that the first result has a price
	When I save the price for the first item
	And I click on the first result
	And I switch to the last tab
	Then assert that the product title on the product page contains <keyword>
	And assert that the product price on the product page is the same as the saved one
	When I switch to Shipping returns and payments tab in the product page
	Then assert that the country <shippingCountry> is in the list of available shipping countries
	When I select sticker <stickerType> in the sticker dropdown in the product page
	And I change quantity to <quantity> in the product page
	And I press Add to cart button
	Then assert that I am on the cart payment page
	And assert that the quantity of the first item in the cart is <quantity>
	And assert that the price of the first item in the cart is for <quantity> items with the saved price

Examples:
	| category       | keyword  | shippingType  | shippingCountry | stickerType    | quantity |
	| Toys & Hobbies | Monopoly | International | Bulgaria        | 4 Western Star | 2        |

