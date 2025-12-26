# Use Cases
## 1. User Login
**Actor:** Employee  
**Description:** User logs into the system

### Preconditions
- User has an active account

### Main Flow
1. User opens login page
2. Enters email and password
3. Clicks login
4. System validates credentials
5. User is redirected to dashboard

### Alternate Flow
- Invalid credentials → error message



## 2. Create Approval Request

**Actor:** Employee  
**Description:** Submit a new approval request

### Preconditions
- User is logged in

### Main Flow
1. User clicks "New Request"
2. Enters request details
3. Submits request
4. System saves request
5. Request status set to "Pending"
---
## 3. Approve Request

**Actor:** Manager  
**Description:** Approve or reject a request

### Preconditions
- Manager is logged in
- Request is pending

### Main Flow
1. Manager opens request
2. Reviews details
3. Clicks approve or reject
4. System updates request status
5. Employee is notified
