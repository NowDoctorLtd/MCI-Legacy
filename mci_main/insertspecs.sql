-- Do this to create prac:spec associations for test data (EF is abysmal at this)
insert into PractitionerSpecialty (PracIdx, SpecIdx, DateCreated) values (1,1,CURRENT_TIMESTAMP);

