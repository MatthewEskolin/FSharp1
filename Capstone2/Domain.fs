//Will Contain Domain Objects Customer and Accounts
module Capstone2.Domain

type Customer = { Name : string }
type Account = { AccountId: System.Guid; Owner: Customer; Balance : decimal }


