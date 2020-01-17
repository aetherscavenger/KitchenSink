# Assumptions
- I assume that the _id represents the external ID from a 3rd party source. I would normally store it as such. For this exercise, I am treating it like an internal id.
- I assume we will have an ELT or ETL process from external parties for any data persistence we might need. For this exercise, I am treating the original files like a data source and am emulating those transformations we would do in flight. Normally we would abstract these business rules into other projects, for now I isolated those into the API.
- I also assume some end points we would not persist the data and transform in flight.

# Questions
## To the Stakeholders/POs
What level of PII protection do we want to implement?
Are we going to plug notifications into an SMS/MMS?

## To The Scrum Master/PM
