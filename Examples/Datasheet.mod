set subject;
set day;
set time;
set subject_senior;
set subject_junior;

set batch;
set batch_subject{batch} within subject;

set day_time within{day, time};
set course_conflict{subject} within subject; # with respect to student
param course_strength{subject};

var X{subject, day_time} binary;

minimize subject_per_day: sum{s in subject, (d,t) in day_time} X[s,d,t];

#All subjects are scheduled
subject to schedule{s in subject}:
	sum{(d,t) in day_time}X[s,d,t]=1;

#Subject and its conflicting subjects cannot be scheduled on same time.
subject to avoid_subject_conflict{(d,t) in day_time, s in subject}:
	 X[s,d,t] + (sum{c in course_conflict[s]} X[c,d,t])/(sum{c in course_conflict[s]}1)<=1;

#All subject of seniors are in evening
#subject to evening {(d,t)in day_time:t=1}:
#	sum{s in subject_senior}X[s,d,t]=0;

#All subject of Junior are in morning
#subject to morning {(d,t)in day_time:t=2}:
#	sum{s in subject_junior}X[s,d,t]=0;

#Subject to Batch conflict
subject to batch_conflict{b in batch,d in day}:
sum{s in batch_subject[b], t in time}
		X[s,d,t]<=2;
		
#Students scheduled at a given time are less than seating capacity
subject to seating_capacity{(d,t) in day_time}:
	sum{s in subject}X[s,d,t]*course_strength[s]<=680;