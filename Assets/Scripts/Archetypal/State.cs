public enum State {
	Inactive, 					// Not existing, unstarted, and/or not waiting to start
	WaitingToStart, 			// Ready to begin, but not doing anything yet
	Starting,					// Setting up
	Active,						// Generally running
	BakerVisible,				// Pre-urgency step of visibility
	BecomingUrgent,				// Step before final immediacy
	Urgent,						// Immediately needs to be handled
	Handling,					// Being handled by user
	Completing					// Shutting down
};
