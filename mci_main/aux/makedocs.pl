#!env perl
use v5.32;
use warnings;

my @FORENAMES_MALE = qw(
Andrew Aaron Arnold Ainsley Antony Alexander Alf
Bryan Bryson Bernard Bruce Ben Barry
Christopher Carl Cyril Ciaran
David Daniel Damon
Edward Edgar Ethel
Felix Fontaine
George Glenn Godwin Graham Gerald
Harold Hubert Hugh Horace
Ian
Joseph James Jonathan
Kenneth
Lawrence Leslie Llaim
Michael Mark Matthew Maximillian Morris
Nicholas Neville
Paul Peter Philip
Quentin
Robert Ryan Roger Rowan
Simon Stanley Samuel Stephen
Terrance
Vincent
William Winston
);

my @FORENAMES_FEMALE = qw(
Amy Annette Anita Alice Allison
Bernadette Beatrice
Carolyn Christine Ciara Claire Catherine Carrie Charlene Chloe
Doreen Danielle Deborah
Ellenor Emma Evangeline
Felicity
Georgina Gail Gillian
Hannah Heather
Jennifer Joanne
Kathlin
Linda Lilly Lorraine Laura
May Maureen Monica Madeline Marian Maxine
Ophelia
Penny Pearl
Rachel Rebecca Ruth
Stephanie Susan
Vivian
Wynona
Yvonne
);

my @SURNAMES = qw(
Anderson Armstrong Alburn Alder Ashen
Bates Brown Bolton Boyce Boyd Blair
Connolly Columbus Caroll Chamberlain Claypool Coxon Currie
Dobbin Dell Delvin
Erskin
Griffin Goodman Green
Hyde Hughes Hamilton
Laverty
Mitchell Moorehead Moore Montgomery McMullan McCallion McCullogh Morrison McGlone
Norris Newton
Oldman Overend O'Leary
Parke Pollard Paulson
Ramsey Rochefort Robinson
Smith Stuart Steele Smyth
Underwood
Wall Whiteside Whitehead Willowfield Woods
);

my $male_len = scalar(@FORENAMES_MALE);
my $female_len = scalar(@FORENAMES_FEMALE);
my $sur_len = scalar(@SURNAMES);

sub get_prac_name {
    # 1/2 chance of male or female...
    my $sex_chance = int rand(10);
    my $sex = $sex_chance >=5 ? "Male" : "Female";

    my $prac_name = $sex_chance >=5 ? $FORENAMES_MALE[int rand($male_len)] :
         $FORENAMES_FEMALE[int rand($female_len)]; 

    $prac_name .= " $SURNAMES[int rand($sur_len)]"; 
    return $prac_name;
}

say get_prac_name for 1..10;
1;
