# dotnet-sdk
Konduto .NET SDK  https://www.konduto.com

## Intro

Welcome! This document will explain how to integrate with Konduto's anti-fraud service so you can begin to spot fraud on your e-commerce website.

Our service uses the visitor's behavior to analyze browsing patterns and detect fraud. You will need to add a **JavaScript** snippet to your website and tag your pages, so we can see your visitors, and call our **REST API** to send purchases, so we can analyze them.

This document refers to the **.NET SDK** used for our API.

## Requirements

* .NET Framework 4.0 or 4.5

## Installation

Install our package avaiable at Nuget: https://www.nuget.org/packages/KdtSdk/

## Getting Started

When a customer makes a purchase you must send the order information to us so we can analyze it. We perform a real-time analysis and return you a **recommendation** of what to do next and a score, a numeric confidence level about that order.

While many of the parameters we accept are optional we recommend you send all you can, because every data point matters for the analysis. The **billing address** and **credit card information** are specially important, though we understand there are cases where you don't have that information.


## Set your API key

You will need an API key to authenticate the requests. Luckily for you the examples below have been populated with a working key, so you can just copy and paste to see how it works.

```c#
// creates a Konduto instance, which is a class that communicates with our API by using HTTP methods.
Konduto konduto = new Konduto("T738D516F09CAB3A2C1EE"); // T738D516F09CAB3A2C1EE is the API key
```

## Creating an order

`KondutoOrder` is a class that models the attributes and behavior of an order.

All entities involved in Konduto's analysis process (e.g customer, shopping cart, payment, etc.) inherit 
from KondutoModel and are under the models package.

```c#
KondutoOrder order = new KondutoOrder
{
  Id = "123",
  TotalAmount = 123.4,
  Customer = customer // customer is an instance of KondutoCustomer
}; 
```		
One can also use the more conventional set-based approach as seen below.

```c#
KondutoOrder order = new KondutoOrder();
order.Id = "123";
order.TotalAmount = 123.4;
order.Customer = customer;
```

Another way of initializing an instance of KondutoModel is to call KondutoModel's fromMap method 
and pass a Map and the instance class as arguments.

>
**NOTICE**: the order created above is really, really simple. The more detail you provide, more accurate Konduto's analysis will be.
>

### Order parameters

Parameter | Description 
--- | ---
id | _(required)_ Unique identifier for each order.
visitor | _(required)_ Visitor identifier obtained from our JavaScript snippet.
total_amount | _(required)_ Total order amount.
shipping_amount | _(optional)_ Shipping and handling amount.
tax_amount | _(optional)_ Taxes amount.
currency | _(optional)_ Currency code with 3 letters (ISO-4217).
installments | _(required)_ Number of installments in the payment plan (min: 1, max: 999).
ip | _(recommended)_ Customer's IPv4 or IPv6 address.
customer | _(required)_ Object containing the customer details.
payment | _(optional)_ Array containing the payment methods.
billing | _(optional)_ Object containing the billing information.
shipping | _(optional)_ Object containing the shipping information.
shopping_cart | _(optional)_ Array containing the items purchased.
analyze | _(optional)_ A boolean indicating if the order should be analyzed. Defaults to **true**.
first_message | _(optional)_ Timestamp (ISO 8601) of the first message exchanged between buyer and seller (for marketplace).
messages_exchanged | _(optional)_ Total number of messages exchanged up to the transaction (for marketplace).
purchased_at | _(optional)_ Date and time when the order was completed in the store (ISO 8601: `YYYY-MM-DDTHH:mm:ssZ`).
recurring | _(optional)_ Boolean indicating if the transaction is a recurring subscription.
risk_level | _(optional)_ Internal risk level assigned to the order (`low`, `medium`, `high`).
sales_channel | _(optional)_ Sales channel used (e.g. `e-commerce`, `mobile`, `pos`, `telemarketing`).
scheduled | _(optional)_ Boolean indicating if the transaction is scheduled (e.g. PIX / Safe Banking).
travel | _(optional)_ Object containing travel and passenger details (flights / buses).
hotel | _(optional)_ Object containing lodging and hotel reservation details.
events | _(optional)_ Array containing ticket and event information.
vehicles | _(optional)_ Object containing vehicle information.
seller | _(optional)_ Object containing marketplace seller details.
point_of_sale | _(optional)_ Object containing physical point-of-sale store details.
agent | _(optional)_ Object containing physical attendant / sales agent details.
delivery | _(optional)_ Object containing delivery and logistics tracking details.
device | _(optional)_ Object containing external mobile/browser device telemetry and fingerprint.
tenant | _(optional)_ Object identifying the sub-account or white-label tenant.
event_type | _(optional)_ Type of banking event (Safe Banking / PIX).
event_details | _(optional)_ Banking event details / subtype (Safe Banking / PIX).
origin_account | _(optional)_ Object containing origin bank account details (Safe Banking / PIX).
destination_accounts | _(optional)_ Array of destination bank accounts (Safe Banking / PIX).

#### Customer information

Parameter | Description 
--- | ---
id | _(required)_ **Unique** identifier for each customer. Can be anything you like (counter, id, e-mail address) as long as it's consistent in future orders.
name | _(required)_ Customer's full name.
email | _(required)_ Customer's e-mail address.
tax_id | _(required)_ Customer's tax id (CPF or CNPJ).
phone1 | _(required)_ Customer's primary phone number.
phone2 | _(optional)_ Customer's secondary phone number.
dob | _(optional)_ Customer's date of birth in `YYYY-MM-DD` format.
created_at | _(optional)_ Customer registration date in store in `YYYY-MM-DD` format.
new | _(optional)_ Boolean indicating if the customer is using a newly created account for this purchase.
vip | _(optional)_ Boolean indicating if the customer is a VIP or frequent buyer.
type | _(optional)_ Customer person type (`PF` for individual, `PJ` for legal entity).
risk_level | _(optional)_ Internal risk level for customer (`low`, `medium`, `high`).
risk_score | _(optional)_ Pre-calculated customer risk score.
mother_name | _(optional)_ Customer's mother's full name.


#### Payment information

Parameter | Description 
--- | ---
type | _(required)_ Payment method type. Accepts: `credit`, `boleto`, `debit`, `transfer`, `voucher`, `balance`, `pix`.
status | _(conditional required)_ The status of the transaction returned by the payment processor (required for `credit` and `debit`). Accepts `approved`, `declined` or `pending`.
bin | _(conditional required)_ First 6 to 10 digits of the customer's card (required for `credit` and `debit`).
last4 | _(conditional required)_ Last 4 digits of the customer's card number (required for `credit` and `debit`).
expiration_date | _(conditional required)_ Card's expiration date in `MMYYYY` format (required for `credit` and `debit`).
amount | _(optional)_ Amount paid with this specific payment method.
currency | _(optional)_ Currency code with 3 letters (ISO-4217).
description | _(optional)_ Additional payment notes or discount details.
tax_id | _(optional)_ Cardholder's tax ID (CPF).
cvv_result | _(optional)_ CVV validation result (`M` for match, `N` for no match, `P` for not processed).
avs_result | _(optional)_ Address verification service result.
sha1 | _(optional)_ Encrypted SHA-1 hash of the card number.
name | _(optional)_ Buyer's name.
holder | _(optional)_ Cardholder's name printed on card.
mcc | _(optional)_ Merchant Category Code.
mid | _(optional)_ Merchant ID in gateway / processor.
3ds_id | _(optional)_ 3D Secure transaction ID.
merchant_tax_id | _(optional)_ Merchant tax ID (CNPJ).
voucher_type | _(optional)_ Voucher type (for voucher payments).


#### Billing address

Parameter | Description 
--- | ---
name | _(optional)_ Cardholder's full name.
address1 | _(optional)_ Cardholder's billing address on file with the bank.
address2 | _(optional)_ Additional cardholder address information.
city | _(optional)_ Cardholder's city.
state | _(optional)_ Cardholder's state.
zip | _(optional)_ Cardholder's ZIP code.
country | _(optional)_ Cardholder's country code (ISO 3166-2).


#### Shipping address

Parameter | Description 
--- | ---
name | _(optional)_ Recipient's full name.
address1 | _(optional)_ Recipient's shipping address.
address2 | _(optional)_ Additional recipient address information.
city | _(optional)_ Recipient's city.
state | _(optional)_ Recipient's state.
zip | _(optional)_ Recipient's ZIP code.
country | _(optional)_ Recipient's country code (ISO 3166-2).
estimatedDate | _(optional)_ Estimated delivery date (ISO 8601: `YYYY-MM-DDTHH:mm:ssZ`).
value | _(optional)_ Shipping value for this delivery.
lat | _(optional)_ Latitude for the shipping destination.
lon | _(optional)_ Longitude for the shipping destination.


#### Shopping cart

Parameter | Description 
--- | ---
sku | _(optional)_ Product or service's SKU or inventory id.
product_code | _(optional)_ Product or service's UPC, barcode or secondary id.
category | _(optional)_ Category code for the item purchased. [See here](http://docs.konduto.com/#n-tables) for the list.
name | _(optional)_ Name of the product or service.
description | _(optional)_ Detailed description of the item.
unit_cost | _(optional)_ Cost of a single unit of this item.
quantity | _(optional)_ Number of units purchased.
discount | _(optional)_ Discounted amount for this item.
created_at | _(optional)_ Timestamp when the item was added to the cart (ISO 8601: `YYYY-MM-DD`).
deliveryType | _(optional)_ Delivery type (e.g. `express`, `standard`).
deliverySlaInMinutes | _(optional)_ Delivery SLA in minutes.
sellerId | _(optional)_ Seller / merchant ID for marketplace orders.
image | _(optional)_ URL of the product image.


#### Delivery and Logistics

Parameter | Description 
--- | ---
delivery_company | _(optional)_ Shipping company or courier name.
delivery_method | _(optional)_ Delivery modality or method.
estimated_shipping_date | _(required)_ Estimated shipping date (ISO 8601: `YYYY-MM-DDTHH:mm:ssZ`).
estimated_delivery_date | _(required)_ Estimated delivery date (ISO 8601: `YYYY-MM-DDTHH:mm:ssZ`).


#### Travel (Flights & Buses)

Parameter | Description 
--- | ---
type | _(required)_ Travel type: `flight` or `bus`.
expiration_date | _(optional)_ Expiration date (ISO 8601).
passengers | _(required)_ Array of passenger objects: `name` _(required)_, `document` _(required)_, `document_type` _(required)_, `dob`, `nationality`, `frequent_traveler`, `special_needs`, `loyalty` (`program`, `category`).
departure | _(required)_ Departure segment object: `origin_city`, `destination_city`, `origin_airport`, `destination_airport`, `date` _(required)_, `number_of_connections`, `class`, `fare_basis`, `company`.
return | _(recommended)_ Return segment object: same fields as `departure`.


#### Hotel & Lodging

Parameter | Description 
--- | ---
name | _(required)_ Hotel or establishment name.
address1 | _(optional)_ Street address of the hotel.
address2 | _(optional)_ Additional hotel address information.
city | _(optional)_ City where hotel is located.
state | _(optional)_ State / province of the hotel.
zip | _(optional)_ ZIP / postal code of the hotel.
country | _(optional)_ Country code (ISO 3166-2).
category | _(optional)_ Hotel category.
rooms | _(required)_ Array of reserved room objects: `number`, `code`, `type`, `check_in_date` _(required)_, `check_out_date`, `number_of_guests`, `board_basis`, `guests` _(required)_.
guests (inside room) | _(required)_ Array of guest objects: `name` _(required)_, `document`, `document_type`, `dob`, `nationality`.


#### Events & Tickets

Parameter | Description 
--- | ---
name | _(required)_ Name of the event, show or concert.
date | _(required)_ Event date and time (ISO 8601: `YYYY-MM-DDTHH:mm:ssZ`).
type | _(required)_ Type of event.
subtype | _(optional)_ Subtype of event.
venue | _(optional)_ Venue object containing `name`, `address`, `city`, `state`, `country`, `capacity`.
tickets | _(optional)_ Array of ticket objects: `id`, `category` _(required)_, `section`, `premium` _(required)_, `attendee` _(required)_.
attendee (inside ticket) | _(required)_ Array of attendee objects: `name`, `document` _(required)_, `document_type`, `dob`.


#### Vehicles

Parameter | Description 
--- | ---
vid | _(optional)_ Vehicle Identification Number (17 characters).
renavam | _(optional)_ Brazilian vehicle registration code (RENAVAM).
registration | _(optional)_ Vehicle registration / plate code.
make | _(required)_ Vehicle manufacturer / brand (e.g. `Toyota`, `Volkswagen`).
model | _(required)_ Vehicle model (e.g. `Corolla`, `Gol`).
type | _(optional)_ Vehicle type.
usage | _(optional)_ Vehicle usage.
owner | _(required)_ Array of owner objects: `name`, `tax_id` _(required)_.


#### Marketplace Seller

Parameter | Description 
--- | ---
id | _(required)_ Unique partner store or seller identifier in marketplace.
name | _(optional)_ Seller / store name.
created_at | _(optional)_ Seller registration date in marketplace (`YYYY-MM-DD`).


#### Physical Point of Sale & Agent

Parameter | Description 
--- | ---
point_of_sale | _(optional)_ Physical POS object: `id` _(required)_, `name` _(required)_, `lat`, `long`, `address`, `city`, `state`, `zip`, `country`.
agent | _(optional)_ Physical attendant / sales agent object: `id` _(required)_, `login`, `name` _(required)_, `tax_id`, `dob`, `category`, `created_at` _(required)_.


#### Device Telemetry & External Device

Parameter | Description 
--- | ---
fingerprint | _(required)_ Device fingerprint hash generated by SDK.
provider | _(optional)_ Fingerprint provider.
category | _(optional)_ Device category.
model | _(optional)_ Device model.
platform | _(optional)_ Client operating system / platform.
manufacturer | _(optional)_ Device manufacturer.
os | _(optional)_ Operating system.
browser | _(optional)_ Browser name.
language | _(optional)_ Device system language.
flash | _(optional)_ Flash support boolean.
cookie | _(optional)_ Cookie support boolean.
javascript | _(optional)_ JavaScript support boolean.
timezone | _(optional)_ Timezone string.
user_id | _(optional)_ User identifier.
ip | _(optional)_ Public IP address observed on device.


#### Multi-tenant

Parameter | Description 
--- | ---
id | _(required)_ Sub-account or partner tenant identifier.
name | _(required)_ Sub-account / tenant brand name.
created_at | _(required)_ Sub-account creation timestamp (ISO 8601: `YYYY-MM-DDTHH:mm:ssZ`).


#### Safe Banking & PIX

Parameter | Description 
--- | ---
event_type | _(optional)_ Type of banking event (e.g. `transfer`, `pix`, `pix_cashin`, `bill_payment`).
event_details | _(optional)_ Banking event details / subtype.
origin_account | _(optional)_ Origin bank account object: `id`, `key_type`, `key_value`, `holder_name`, `holder_tax_id`, `bank_code`, `bank_name`, `bank_branch`, `bank_account`, `balance`.
destination_accounts | _(optional)_ Array of destination bank account objects: `id`, `key_type`, `key_value`, `holder_name`, `holder_tax_id`, `bank_code`, `bank_name`, `bank_branch`, `bank_account`, `amount`.


## Sending an order for analysis.

After creating the order, sending it to Konduto's analysis is very simple.

```c#
if(order.IsValid()){
	try {
		konduto.Analyze(order);
	// A KondutoException will be thrown if the response is anything other than 200 OK.
	// You can catch more specific exceptions if you want to (e.g KondutoHTTPBadRequestException).
	catch(KondutoException e) {
		// Put any exception handling here.
		e.printStackTrace();
		persistAsNotAnalyzed(order, e.getMessage());
	}
} else {
    LOGGER.debug(order.getErrors());
}
```

Notice that if the analysis fails, a **KondutoException** will be thrown. Handle it as you wish.

After the analysis, some order attributes will be filled. For example the recommendation.

```c# 
// The command below should print something like "Konduto recommendation is to APPROVE".
Console.WriteLine("Konduto recommendation is to: " + order.Recommendation);
```

## Querying an order from our servers.

In order to do that use the Konduto class in the following way:

```c#
try 
{
	KondutoOrder order = konduto.GetOrder(orderId); // orderId is a String
} 
catch (KondutoException e) 
{
	// Exception handling code
}
```

## Updating an order status

```c#
try 
{
	// the order status will be set to newStatus if the request succeeds.
	konduto.UpdateOrderStatus(orderId, newStatus, "some comments"); 
} 
catch (KondutoException e) 
{
	// Exception handling code
}
```

Parameter | Description 
--- | ---
status | _(required)_ New status for this transaction. Either `approved`, `declined` or `fraud`, when you have identified a fraud or chargeback.
comments | _(required)_ Reason or comments about the status update.

## Reference Tables

Please [click here](http://docs.konduto.com/#n-tables) for the Currency and Category reference tables.

## Troubleshooting

If you experience problems sending orders for analysis, querying orders or updating order status, it might be a good idea
to call `konduto.Debug()`. This will print out the API Key, the endpoint, the request body and the response body.

## Support

Feel free to contact our [support team](mailto:support@konduto.com) if you have any questions or suggestions!

## Publish in nuget 

[How to publish in Nuget](https://learn.microsoft.com/en-us/nuget/nuget-org/publish-a-package)

### Deploy Local

```docker
docker build -t gerador-sdk .

docker run --rm -v "$(pwd)/pacotes:/output" gerador-sdk
<!-- Output file local KdtSdk.version.X.X.nupkg -->

```

