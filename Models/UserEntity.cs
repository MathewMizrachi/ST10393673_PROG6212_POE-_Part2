using Microsoft.Azure.Cosmos.Table;
using System;

namespace ST10393673_PROG6212_POE.Models
{
    public class UserEntity : TableEntity
    {
        // Constructor: Set PartitionKey and RowKey
        public UserEntity(string email)
        {
            PartitionKey = "Users"; // Partitioning users by the "Users" partition
            RowKey = email;         // Unique key for each user based on email (could use GUID if needed)
        }

        // Parameterless constructor for Azure Table SDK
        public UserEntity() { }

        // Properties for User Information
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Email
        {
            get { return RowKey; }  // Email is stored as RowKey
            set { RowKey = value; } // Ensure it aligns with RowKey for storage purposes
        }

        public string PasswordHash { get; set; } // Store hashed password
        public DateTime RegisteredDate { get; set; } // Store registration date

        // Optional: Add other metadata for the user (e.g., roles, status)
        public string Role { get; set; } = "User"; // Default role set to "User"
        public bool IsActive { get; set; } = true; // Active flag for deactivating user accounts
    }
}
