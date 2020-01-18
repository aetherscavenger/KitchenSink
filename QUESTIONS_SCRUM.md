# Assumptions
- I assume that the _id represents the external ID from a 3rd party source. I would normally store it as such. For this exercise, I am treating it like an internal id.
- I assume we will have an ELT or ETL process from external parties for any data persistence we might need. For this exercise, I am treating the original files like a data source and am emulating those transformations we would do in flight. Normally we would abstract these business rules into other projects, for now I isolated those into the API.
- I also assume some end points we would not persist the data and transform in flight.
- Tag management assumes uniqueness, however the data coming in is NOT unique implying it allows the user to add multiple non-unique tags however, that's absurd, we should fix that in the future.
- I assume delete is not the same as inactive.
- I assume the front end will be secured, however, I only secured the API at this time using basic auth.
- I assume we will have multiple different data sources. I have created preliminary aggregators and transformers to highlight such a possiblity.

# Questions
## To the Stakeholders/POs
- What level of PII protection do we want to implement?
- Are we going to plug notifications into an SMS/MMS?

## To The Scrum Master/PM
- How many future integrations are we expecting.
- Who is in charge of the