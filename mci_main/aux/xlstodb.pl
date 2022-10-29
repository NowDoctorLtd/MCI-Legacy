#!env perl
# Read XLS into database.

# !! !! !! Enable this to skip headers in each worksheet !! !! !!
my $SKIP_FIRST_ROW = 1;

use warnings;
use v5.32;
use Data::Dumper;

# cpan mods
use Spreadsheet::ParseXLSX;

# globals
my ($sourceXls, $workbook, $parser, $json);

my $BANNER = << 'EOF';
Convert excel worksheets into JSON files. Author: MJB. (23/12/21)
<source>.clsx will be read and parsed for worksheets. Each of the first two
cells in each column will be treated as key:value in JSON.
Each worksheet name will be used made into its own JSON file.

Usage:
./xlstojson.pl <source>.xlsx

Eg, ./xlstojson.pl welsh.xlsx 
Will produce a JSON file for each worksheet inside welsh.xlsx
EOF


# Begin exec, read args array
die ($BANNER) if (scalar @ARGV != 1);
($sourceXls) = @ARGV;

# init excel reader
$parser = Spreadsheet::ParseXLSX->new;
$workbook = $parser->parse($sourceXls);
die "Problems parsing Excel file: $!" unless defined $workbook;

# read each worksheet 
for my $worksheet ( $workbook->worksheets() ) {
    my %wsHash;
    my $wsName = $worksheet->get_name();
    my ($rowMin, $rowMax) = $worksheet->row_range();

    say "Reading worksheet $wsName";
    for my $row ( $rowMin .. $rowMax ) {
        next if ($row == 0 && $SKIP_FIRST_ROW);
        my $cell0 = $worksheet->get_cell($row, 0);
        next unless $cell0;
        my $cell1 = $worksheet->get_cell($row, 1);
        next unless $cell1;
        $wsHash{ $cell0->value() } = $cell1->value();
    }
    print Dumper %wsHash;
}
say "Process complete.";

