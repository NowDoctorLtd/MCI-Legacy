-- Do this to create prac:spec associations for test data (EF is abysmal at this)
insert into PractitionerSpecialty (PracIdx, SpecIdx, DateCreated) values (1,1,CURRENT_TIMESTAMP),(2,2,CURRENT_TIMESTAMP),(3,3,CURRENT_TIMESTAMP),(4,3,CURRENT_TIMESTAMP),(5,4,CURRENT_TIMESTAMP);

