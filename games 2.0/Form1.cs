using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;
using mshtml;
using System.Data.Sql;
using System.Data.SqlClient;

namespace games_2._0
{

    public partial class Form1 : Form
    {
        bool webException = false;
        #region db vars
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        List<string> leg = new List<string>();
        WebClient web = new WebClient();
        #region array
        string[,] teamConv = new string[,] {
                { "Bylis Ballsh",  "Bylis" },
            { "Korca","Skenderbeu"},
            { "Tërbuni Pukë","Puka"},
            { "Teuta Durres","Teuta"},
            { "CS Constantine","Constantine"},
            { "DRB Tadjenanet","Tadjenant"},
            { "ES Sétif","ES Setif"},
            { "JS Kabylie","Kabylie"},
            { "JS Saoura","Saoura"},
            { "MC Oran","Oran"},
            { "MO Béjaïa","MO Bejaia"},
            { "NA Hussein Dey","Hussein Dey"},
            { "RC Arbaa","Arba"},
            { "RC Relizane","Relizane"},
            { "USM El Harrach","Harrach"},
            { "Adelaide Utd","Adelaide United"},
            { "Central Coast","Central Coast Mariners"},
            { "Melbourne Vict.","Melbourne Victory"},
            { "Wellington","Wellington Phoenix"},
            { "Western Sydney","WS Wanderers"},
            { "Austria Wien","Austria Vienna"},
            { "Grödig","Grodig"},
            { "Pellets WAC","AC Wolfsberger"},
            { "Rapid Wien","Rapid Vienna"},
            { "Ried SV","Ried"},
            { "AZAL Baku","AZAL PFK"},
            { "Kapaz Ganja","Kapaz"},
            { "Karabakh","Qarabag"},
            { "Neftci","Neftci Baku"},
            { "Ravan Baku","Ravan"},
            { "Sumgayit","SumQayit"},
            { "Zira FK","Zira"},
            { "Beveren","Waasland-Beveren"},
            { "Mouscron-P.","Mouscron Peruwelz"},
            { "Oud-Heverlee","Leuven"},
            { "Racing Genk","Genk"},
            { "Sint-Truiden","St. Truiden"},
            { "Standard Liege","St. Liege"},
            { "Zulte-Waregem","Waregem"},
            { "Antwerp","FC Antwerp"},
            { "Dessel Sport","Dessel"},
            { "Excelsior","Virton"},
            { "Geel","ASV Geel"},
            { "Lommel United","Lommel Utd"},
            { "Roeselare","KSV Roeselare"},
            { "Seraing United","Seraing United"},
            { "WS Bruwelles","Bruxelles"},
            { "Eendracht Aalst","Aalst"},
            { "FC Gullegem","Gullegem"},
            { "La Louvière","UR La Louviere"},
            { "RES Acrenoise","Acren"},
            { "Sint-Eloois-W.","Saint Eloois"},
            { "Sparta Petegem","Petegem"},
            { "Berchem","K. Berchem Sport"},
            { "Cappellen","Capellen"},
            { "Diegem Sport","Diegem"},
            { "FCO Beerschot","Beerschot Wilrijk"},
            { "Oosterwijk","Oosterzonen"},
            { "RFC Liège","RFC Liege"},
            { "RRC Hamoir","Hamoir"},
            { "Sprimont","Sprimont-Comblain"},
            { "Tempo Overijse","Overijse"},
            { "Woluwe Z.","Woluwe Zaventem"},
            { "Blagoevgrad","Pirin Blagoevgrad"},
            { "Levski Sofia","Levski"},
            { "Dinamo Zagreb","D. Zagreb"},
            { "Inter Zapresic","Zaprešić"},
            { "NK Istra","Istra 1961"},
            { "NK Lokomotiva","Lok. Zagreb"},
            { "Slaven","Belupo"},
            { "AEK Larnaka","AEK Larnaca"},
            { "AEP Paphos","Paphos"},
            { "APOEL Nicosia","APOEL"},
            { "Aris Limassol","Aris"},
            { "Enosis","Paralimni"},
            { "Omonia Nicosia","Omonia"},
            { "AaB Aalborg","Aalborg"},
            { "Aarhus GF","Aarhus"},
            { "Brondby IF","Brondby"},
            { "FC Midtjylland","Midtjylland"},
            { "Hobro ","Hobro"},
            { "OB Odense","Odense"},
            { "Randers","Randers FC"},
            { "Sonderjylland","Sonderjyske"},
            { "HB Køge","Koge"},
            { "Helsingør","Helsingor"},
            { "Vejle Boldklub","Vejle"},
            { "Vendsyssel","Vendsyssel FF"},
            { "Deportivo Quito","Dep. Quito"},
            { "Independiente","Ind. del Valle"},
            { "LDU de Loja","LDU Loja"},
            { "LDU de Quito","LDU Quito"},
            { "River Ecuador","River Plate Ecuador"},
            { "Leicester City","Leicester"},
            { "Manchester Utd","Manchester United"},
            { "Norwich City","Norwich"},
            { "Swansea City","Swansea"},
            { "West Bromwich","West Brom"},
            { "West Ham Utd","West Ham"},
            { "Birmingham City","Birmingham"},
            { "Brighton & Hove","Brighton"},
            { "Cardiff City","Cardiff"},
            { "Derby County","Derby"},
            { "Ipswich Town","Ipswich"},
            { "Leeds Utd","Leeds"},
            { "Milton Keynes","Milton Keynes Dons"},
            { "Nottm Forest","Nottingham"},
            { "QP Rangers","QPR"},
            { "Wolverhampton","Wolves"},
            { "Burton Albion","Burton"},
            { "Coventry City","Coventry"},
            { "Crewe Alexandra","Crewe"},
            { "Fleetwood","Fleetwood Town"},
            { "Gillingham","Gillingham FC"},
            { "Southend Utd","Southend"},
            { "Swindon Town","Swindon"},
            { "Wigan Athletic","Wigan"},
            { "Carlisle Utd","Carlisle"},
            { "Dagenham & R","Dagenham & Red."},
            { "Exeter City","Exeter"},
            { "Luton Town","Luton"},
            { "Wimbledon","AFC Wimbledon"},
            { "Yeovil Town","Yeovil"},
            { "Aldershot Town","Aldershot"},
            { "Dover Athletic","Dover Ath."},
            { "Halifax Town","Halifax"},
            { "Torquay Utd","Torquay"},
            { "Welling Utd","Welling"},
            { "AFC Fylde","Fylde"},
            { "Alfreton Town","Alfreton"},
            { "Boston Utd","Boston"},
            { "Brackley Town","Brackley"},
            { "Bradford Park","Bradford PA"},
            { "Corby Town","Corby"},
            { "FC United","United of Manchester"},
            { "Harrogate Town","Harrogate"},
            { "Lowestoft Town","Lowestoft"},
            { "Solihull Moors","Solihull"},
            { "Telford Utd","Telford"},
            { "Worcester City","Worcester"},
            { "Bishops","Stortford"},
            { "Chelmsford City","Chelmsford"},
            { "Concord Rangers","Concord"},
            { "Eastbourne","Eastbourne Borough"},
            { "Ebbsfleet Utd","Ebbsfleet"},
            { "Gosport Borough","Gosport"},
            { "Havant & W.","Havant & W"},
            { "Hemel Hempstead","Hemel"},
            { "Maidenhead Utd","Maidenhead"},
            { "St Albans City","St. Albans"},
            { "Truro City","Truro"},
            { "Bognor Regis","Bognor"},
            { "Brentwood Town","Brentwood"},
            { "Burgess Hill To","Burgess Hill"},
            { "Canvey Island","Canvey"},
            { "Grays Athletic","Grays"},
            { "Hampton & Rich.","Hampton"},
            { "Harrow Borough","Harrow"},
            { "Metropolitan P","Metropolitan"},
            { "Needham Market","Needham"},
            { "Staines Town","Staines"},
            { "Wingate & F.","Wingate & Finchley"},
            { "Blyth Spartans","Blyth"},
            { "Darlington 1883","Darlington"},
            { "Grantham Town","Grantham"},
            { "Ilkeston FC","Ilkeston"},
            { "Matlock ","Matlock"},
            { "Mickleover Spor","Mickleover"},
            { "Nantwich Town","Nantwich"},
            { "Ramsbottom Utd","Ramsbottom"},
            { "Rushall Olympic","Rushall"},
            { "Salford City FC","Salford"},
            { "Sutton Coldfiel","Sutton Coldfield"},
            { "Whitby Town","Whitby"},
            { "Bedworth United","Bedworth"},
            { "Biggleswade","Biggleswade Town"},
            { "Chesham Utd","Chesham"},
            { "Chippenham","Chippenham Town"},
            { "Dunstable","Dunstable Town"},
            { "Frome Town","Frome"},
            { "Hitchin Town","Hitchin"},
            { "Redditch Utd","Redditch"},
            { "Slough Town","Slough"},
            { "St Neots Town","St. Neots"},
            { "Stratford Town","Stratford"},
            { "Chelsea-U21","Chelsea U21"},
            { "Everton-U21","Everton U21"},
            { "Leicester-U21","Leicester U21"},
            { "Liverpool-U21","Liverpool U21"},
            { "Man. City U21","Manchester City U21"},
            { "Man. Utd-U21","Manchester United U21"},
            { "Middlesbrough-U","Middlesbrough U21"},
            { "Norwich-U21","Norwich U21"},
            { "Reading-U21","Reading U21"},
            { "Southampton-U21","Southampton U21"},
            { "Sunderland-U21","Sunderland U21"},
            { "Tottenham-U21","Tottenham U21"},
            { "Arsenal-U21","Arsenal U21"},
            { "Aston Villa-U21","Aston Villa U21"},
            { "Blackburn-U21","Blackburn U21"},
            { "Brighton-U21","Brighton U21"},
            { "Derby-U21","Derby U21"},
            { "Fulham-U21","Fulham U21"},
            { "Newcastle-U21","Newcastle Utd U21"},
            { "Stoke City-U21","Stoke City U21"},
            { "Swansea-U21","Swansea U21"},
            { "West Brom-U21","West Brom U21"},
            { "West Ham-U21","West Ham U21"},
            { "Wolves-U21","Wolves U21"},
            { "Saint-Etienne","St Etienne"},
            { "Ajaccio","AC Ajaccio"},
            { "Bourg-Péronnas","Bourg Peronnas"},
            { "Créteil","Creteil"},
            { "Belfort","ASM Belfort"},
            { "Béziers","Beziers"},
            { "Consolat M.","Consolat"},
            { "Épinal","Epinal"},
            { "Fréjus","Frejus Saint Raphael"},
            { "Luçon","Lucon"},
            { "Orléans","Orleans"},
            { "FC Augsburg","Augsburg"},
            { "FC Köln","Köln"},
            { "Frankfurt","Eintracht Frankfurt"},
            { "FSV Mainz 05","Mainz"},
            { "Hannover 96","Hannover"},
            { "Leverkusen","Bayer Leverkusen"},
            { "Mönchengladb.","B. Monchengladbach"},
            { "Schalke 04","Schalke"},
            { "Stuttgart","VfB Stuttgart"},
            { "1860 München","Munich 1860"},
            { "Bielefeld","Arminia Bielefeld"},
            { "Dusseldorf ","Dusseldorf"},
            { "FC Nürnberg","Nurnberg"},
            { "Karlsruher SC","Karlsruher"},
            { "MSV Duisburg","Duisburg"},
            { "Sankt Pauli","St. Pauli"},
            { "Dynamo Dresden","Dresden"},
            { "Erzgebirge Aue","Aue"},
            { "Hallescher FC","Hallescher"},
            { "Mainz B","Mainz II"},
            { "Osnabrück","VfL Osnabruck"},
            { "Preußen Münster","Preussen Munster"},
            { "RW Erfur","Erfurt"},
            { "Sonnenhof","Sonnenhof Großaspach"},
            { "St. Kickers","Stutt. Kickers"},
            { "Stuttgart B","Stuttgart II"},
            { "Werder Bremen B","Bremen II"},
            { "Würzburger K.","Wurzburger Kickers"},
            { "Braunschweig B","Braunschweig II"},
            { "Drochtersen/A.","Drochtersen / Assel"},
            { "Goslarer SC","Goslarer"},
            { "Hamburger B","Hamburger SV II"},
            { "Hannover B","Hannover II"},
            { "Havelse","TSV Havelse"},
            { "Lüneburger SK","Luneburger Hansa"},
            { "St. Pauli Am","St. Pauli II"},
            { "VfV Borussia 06","Hildesheim"},
            { "Wolfsburg B","Wolfsburg II"},
            { "Berliner AK","Berliner AK 07"},
            { "Budissa Bautzen","Bautzen"},
            { "Carl Zeiss Jena","Jena"},
            { "FC Schönberg","Schönberg"},
            { "Hertha Berlin B","Hertha Berlin II"},
            { "Luckenwade","Luckenwalde"},
            { "Oberlausitz ","Oberlausitz"},
            { "RB Leipzig Am.","RB Leipzig II"},
            { "Aachen","Alemannia Aachen"},
            { "Düsseldorf B","Dusseldorf II"},
            { "Erndtebrück","Erndtebruck"},
            { "FC Köln B","Köln II"},
            { "FC Kray","Kray"},
            { "M`gladbach B","B. Monchengladbach II"},
            { "Rödinghausen","Rodinghausen"},
            { "Rot Weiss Ahlen","Ahlen"},
            { "Rot Weiss Essen","RW Essen"},
            { "SC Verl","Verl"},
            { "Schalke 04 B","Schalke II"},
            { "Viktoria Köln","Viktoria Koln"},
            { "Wegberg-Beeck","FC Wegberg-Beeck"},
            { "Wiedenbrück","Wiedenbruck"},
            { "AEK Athens","AEK"},
            { "Olympiakos","Olympiakos Piraeus"},
            { "Panaitolikos","Panetolikos"},
            { "Platanias","Platanias FC"},
            { "Tripolis","Asteras Tripolis"},
            { "Xanthi","Skoda Xanthi"},
            { "Agrotikos","A. Asteras"},
            { "Apollon Smirnis","Smyrnis"},
            { "Karditsas","Karditsa"},
            { "Larissa","AEL Larissa"},
            { "Olymp. Volos","O. Volos"},
            { "Panaigialeios","Panegialios FC"},
            { "Trikala","Trikala FC"},
            { "ADO Den Haag","Den Haag"},
            { "Ajax Amsterdam","Ajax"},
            { "De Graafschap","Graafschap"},
            { "FC Groningen","Groningen"},
            { "FC Twente","Twente"},
            { "FC Utrecht","Utrecht"},
            { "Heracles Almelo","Heracles"},
            { "NEC Nijmegen","Nijmegen"},
            { "PEC Zwolle","Zwolle"},
            { "PSV Eindhoven","PSV"},
            { "Roda JC","Roda"},
            { "Vitesse Arnhem","Vitesse"},
            { "B. Jerusalem","Beitar Jerusalem"},
            { "Bnei Sakhnin","Sakhnin"},
            { "Bnei Yehuda","Yehuda"},
            { "H. Hapoel Kfar","Hapoel Kfar-Saba"},
            { "Hapoel Acre","H. Akko"},
            { "Hapoel Raanana","H. Raanana"},
            { "Ironi Kiryat","Shmona"},
            { "M. Petah Tikva","Maccabi Petah Tikva"},
            { "M. Tel Aviv","Maccabi Tel Aviv"},
            { "Maccabi Netanya","Netanya"},
            { "Hellas Verona","Verona"},
            { "Inter Milan","Inter"},
            { "Lazio Roma","Lazio"},
            { "Virtus Entella","Entella"},
            { "Virtus Lanciano","Lanciano"},
            { "Bassano Virtus","Bassano"},
            { "Feralpi Salò","FeralpiSalo"},
            { "Südtirol","Sudtirol"},
            { "L`Aquila","L Aquila"},
            { "Fidelis Andria","Andria"},
            { "Lupa Castelli R","Castelli Romani"},
            { "Nuova Cosenza","Cosenza"},
            { "Al Ahly (JOR)","Al Ahli"},
            { "Al Baq`a","Al Buqaa"},
            { "Al Faisaly","Al Faisaly Amman"},
            { "Al Jazeera Amma","Al Jazeera Amman"},
            { "Kufer Soom","Kfarsoum"},
            { "Balzan Youths","Balzan"},
            { "Pembroke Athlet","Pembroke"},
            { "Sliema Wanderer","Sliema"},
            { "Tarxien Rainbow","Tarxien"},
            { "Difaâ El Jadida","Difaâ El Jadidi"},
            { "Ittihad de Tang","IR Tanger"},
            { "KAC Kénitra","KAC Kenitra"},
            { "Khouribga","Olympique Khouribga"},
            { "Maghreb Fès","Maghreb Fez"},
            { "Marrakech","Kawkab Marrakech"},
            { "Olympique Safi","Olympique de Safi"},
            { "Wyd. Casablanca","Wydad Casablanca"},
            { "Ballinamallard ","Ballinamallard"},
            { "Ballymena Utd","Ballymena"},
            { "Carrick Rangers","C. Rangers"},
            { "Gornik Leczna","Leczna"},
            { "Gornik Zabrze","Gornik Z."},
            { "KS Cracovia","Cracovia"},
            { "Legia Warsaw","Legia"},
            { "Ruch Chorzow","Ruch"},
            { "Wisla Krakow","Wisla"},
            { "Zaglebie Lubin","Zaglebie"},
            { "Paços Ferreira","Ferreira"},
            { "Sporting Braga","Braga"},
            { "Sporting CP","Sporting"},
            { "Uniao Madeira","U. Madeira"},
            { "Vitoria Setubal","Setubal"},
            { "Deportivo Aves","Aves"},
            { "Famalicão","Famalicao"},
            { "Farense","SC Farense"},
            { "Guimarães B","Guimaraes B"},
            { "Oriental Lisboa","Oriental"},
            { "Sp. Covilha","Covilha"},
            { "UD Oliveirense","Oliveirense"},
            { "ACS Poli","ACS Poli Timisoara"},
            { "Astra Giurgiu","Astra"},
            { "Botosani","FC Botosani"},
            { "Constanta","V. Constanta"},
            { "CSMS Iasi","CSMS Iaşi"},
            { "CSU Craiova","CS U. Craiova"},
            { "Dinamo Bucarest","Din. Bucuresti"},
            { "FC Voluntari","Voluntari"},
            { "Pandurii Targu","Pandurii"},
            { "Steaua Bucarest","Steaua Bucuresti"},
            { "Târgu Mures","ASA Targu Mures"},
            { "Amkar Perm","Amkar"},
            { "Dinamo Moscow","Dynamo Moscow"},
            { "FC Krasnodar","Krasnodar"},
            { "Krylya Sovetov","Krylya Sovetov Samara"},
            { "Kuban Krasnodar","Kuban"},
            { "Lokomotiv M.","Lokomotiv Moscow"},
            { "Rostov","FK Rostov"},
            { "Saransk","M. Saransk"},
            { "Terek Grozny","Terek Grozni"},
            { "Zenit","Zenit Petersburg"},
            { "Baikal","Baikal Irkutsk"},
            { "Fakel Voronezh","F. Voronezh"},
            { "FC Tyumen","Tyumen"},
            { "Shinik","Shinnik Yaroslavl"},
            { "SKA-Energia","SKA Energiya"},
            { "Sokol Saratov","Saratov"},
            { "Sp. Moscow B","Spartak Moscow 2"},
            { "Volga Novgorod","Volga N. Novgorod"},
            { "Volgar Astrakha","Volgar-Astrakhan"},
            { "Zenit B","Zenit Petersburg 2"},
            { "Partick Thistle","Partick"},
            { "Alloa Athletic","Alloa"},
            { "Glasgow Rangers","Rangers"},
            { "Raith Rovers","Raith"},
            { "St Mirren","St. Mirren"},
            { "Ayr Utd","Ayr"},
            { "Brechin City","Brechin"},
            { "Annan Athletic","Annan"},
            { "Berwick Rangers","Berwick"},
            { "East Stirling","East Stirlingshire"},
            { "Queen`s Park","Queen's Park"},
            { "Stirling Albion","Stirling"},
            { "Borac Cacak","Borac"},
            { "Cukaricki","FK Čukarički"},
            { "FK Metalac","Metalac"},
            { "FK Radnik","Surdulica"},
            { "FK Spartak","Sp. Subotica"},
            { "Mladost Lucani","Mladost"},
            { "OFK Belgrade","OFK Beograd"},
            { "RAD Belgrade","Rad Beograd"},
            { "Red Star","FK Crvena zvezda"},
            { "Vozdovac","FK Vozdovac"},
            { "CM Celje","Celje"},
            { "Gorica","ND Gorica"},
            { "Krka","NK Krka"},
            { "Krsko Posavje","Krsko"},
            { "Ljubljana","O. Ljubljana"},
            { "Rudar Velenje","Velenje"},
            { "Chippa United","Chippa Utd."},
            { "F. State Stars","Free State Stars"},
            { "Mamelodi","Mamelodi Sundowns"},
            { "Polokwane City","Polokwane"},
            { "Pretoria Univ.","Pretoria U."},
            { "Athletic Bilbao","Ath Bilbao"},
            { "Atletico Madrid","Atl. Madrid"},
            { "Deportivo","Dep. La Coruna"},
            { "FC Barcelona","Barcelona"},
            { "FC Sevilla","Sevilla"},
            { "Granada","Granada CF"},
            { "Real Betis","Betis"},
            { "Sporting Gijon","Gijon"},
            { "Bilbao B","Ath Bilbao B"},
            { "Gimnàstic","Gimnastic"},
            { "Leganés","Leganes"},
            { "Mirandés","Mirandes"},
            { "Real Oviedo","R. Oviedo"},
            { "Atlético Astorg","Atl. Astorga"},
            { "Cacereño","Cacereno"},
            { "CD Lealtad","Lealtad"},
            { "Coruxo","Coruxo FC"},
            { "Gijón B","Gijon B"},
            { "Peña Sport","Pena"},
            { "Racing","Santander"},
            { "Racing Ferrol","Ferrol"},
            { "UD Logroñés","UD Logrones"},
            { "UD Somozas","Somozas"},
            { "CD Ebro","Ebro"},
            { "CD Mensajero","Mensajero"},
            { "CF Rayo Majadah","Rayo Majadahonda"},
            { "Real Sociedad B","R. Sociedad B"},
            { "Real Unión","R. Union"},
            { "SD Gernika","Gernika Club"},
            { "SD Leioa","Leioa"},
            { "Talavera","CF Talavera"},
            { "UD Socuéllamos","Socuellamos"},
            { "CD Eldense","Eldense"},
            { "CD Llosetense","Llosetense"},
            { "Huracán","Huracan"},
            { "L`Hospitalet","L Hospitalet"},
            { "Levante B","Levante UD B"},
            { "Olímpic Xàtiva","Olimpic Xativa"},
            { "Reus","Reus Deportiu"},
            { "UD Cornella","Cornella"},
            { "UE Olot","Olot"},
            { "Almería B","Almeria B"},
            { "Cádiz","Cadiz"},
            { "Granada B","Granada CF B"},
            { "Mérida","Merida AD"},
            { "Real Betis B","Betis B"},
            { "Real Jaen","Jaen"},
            { "Real Murcia","Murcia"},
            { "Recreativo","Recreativo Huelva"},
            { "Sevilla Atlétic","Sevilla B"},
            { "Akhisar","Akhisar Genclik Spor"},
            { "Ankaraspor","Osmanlispor"},
            { "Istanbul BB","Basaksehir"},
            { "Adanaspor","Adanaspor AS"},
            { "Erciyesspor","Kayseri Erciyesspor"},
            { "Gaziantep","Gaziantep BB"},
            { "Göztepe","Goztepe"},
            { "Karabukspor","Kardemir Karabuk"},
            { "Yeni Malatyaspo","Yeni Malatyaspor"},
            { "Airbus UK","Airbus"},
            { "Bala Town","Bala"},
            { "Bangor City","Bangor"},
            { "Carmarthen","Carmarthen Town"},
            { "Connah`s Quay","Connahs Q."},
            { "The New Saints","TNS"},
            { "Al Ahly Cairo","Al Ahly"},
            { "Al Masry","El Masry"},
            { "Al Mokawloon","Arab Contractors"},
            { "Aswan FC","Aswan SC"},
            { "El Dakhleya","El Daklyeh"},
            { "El Entag El Har","El-Entag El-Harby"},
            { "El Shorta","El-Shorta"},
            { "ENPPI","Enppi"},
            { "Ghazl El Mahall","Ghazl El Mahallah"},
            { "Haras","Haras El Hodood"},
            { "Ismaily","El Ismaily"},
            { "Misr El Makasa","Misr Elmaqasah"},
            { "Talaea El Gaish","El Gaish"},
            {"Audax Italiano","A. Italiano" },
            {"Iquique","Deportes Iquique" },
            {"O`Higgins","O'Higgins" },
            {"San Marcos","San Marcos de Arica" },
            {"U. Concepcion","U. De Concepcion" },
            {"Unión Española","U. Espanola" },
            {"Coquimbo Unido","Coquimbo" },
            {"Curicó Unido","Curico Unido" },
            {"Deportes Concep","D. Concepcion" },
            {"Deportes Copiap","Copiapo" },
            {"Deportes La Ser","La Serena" },
            {"Everton CD","Everton" },
            {"Puerto Montt","D. Puerto Montt" },
            {"Santiago Mornin","S. Morning" },
            {"Unión San Felip","San Felipe" },
            {"AD Municipal","Liberia" },
            {"Universidad CR","U.C.R." },
            {"Banik Ostrava","Ostrava" },
            {"Bohemians","Bohemians 1905" },
            {"Slovan Liberec","Liberec" },
            {"Tescoma Zlin","Zlin" },
            {"Viktoria Plzen","Plzen" },
            {"Zbrojovka Brno","Brno" },
            {"CF America","Club America" },
            {"Dorados","Dorados de Sinaloa" },
            {"Guadalajara","Guadalajara Chivas" },
            {"Jaguares","Chiapas" },
            {"Leon","Club Leon" },
            {"Pumas UNAM","U.N.A.M.- Pumas" },
            {"Tigres","U.A.N.L.- Tigres" },
            {"Tijuana","Club Tijuana" },
            {"Altamira","Cafetaleros de Tapachula" },
            {"Cimarrones","Cimarrones de Sonora" },
            {"Est. Tecos","Zacatecas" },
            {"Irapuato","Murcielagos" },
            {"Juárez","Zacatecas" },
            {"Mérida","Venados" },
            {"Oaxaca","Alebrijes Oaxaca" },
            {"San Luis","Atl. San Luis" },
            {"Tepic","Dep. Tepic" },
            {"U. Guadalajara","Leones Negros" },
            {"Almere City FC","Almere City" },
            {"FC Den Bosch","Den Bosch" },
            {"FC Dordrecht","Dordrecht" },
            {"FC Eindhoven","Eindhoven FC" },
            {"FC Emmen","Emmen" },
            {"FC Oss","Oss" },
            {"FC Volendam","Volendam" },
            {"Fortuna Sittard","Sittard" },
            {"Go Ahead Eagles","G.A. Eagles" },
            {"Helmond Sport","Helmond" },
            {"MVV Maastricht","Maastricht" },
            {"NAC Breda","Breda" },
            {"RKC Waalwijk","Waalwijk" },
            {"Sparta","Sparta Rotterdam" },
            {"VVV","Venlo" },
            {"Cerro Porteño","Cerro Porteno" },
            {"Dep. Capiata","Deportivo Capiata" },
            {"General Caballe","General Caballero" },
            {"General Díaz","Diaz" },
            {"Guaraní","Guarani" },
            {"Libertad","Libertad Asuncion" },
            {"Nacional","Nacional Asuncion" },
            {"Olimpia","Olimpia Asuncion" },
            {"River Plate Asu","River Plate" },
            {"Sol de América","Sol de America" },
            {"Sport. Luqueño","Sp. Luqueno" },
            {"FC Zurich","Zurich" }
        };

    

    #endregion

    #endregion
    int Factorial(int i)
        {
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }

    public Form1()
    {
        InitializeComponent();
            #region list assign
            //List<string> leg = new List<string>();
            leg.Add("albania");
        leg.Add("algeria");
        leg.Add("australia");
        leg.Add("austria");
        leg.Add("azerbaidjan");
        leg.Add("belgium");
        leg.Add("belgium2");
        leg.Add("belgium3");
        leg.Add("belgium4");
        leg.Add("bulgaria");
        leg.Add("croatia");
        leg.Add("cyprus");
        leg.Add("denmark");
        leg.Add("denmark2");
        leg.Add("ecuador");
        leg.Add("england");
        leg.Add("england2");
        leg.Add("england3");
        leg.Add("england4");
        leg.Add("england5");
        leg.Add("england6");
        leg.Add("england7");
        leg.Add("england8");
        leg.Add("england9");
        leg.Add("england10");
        leg.Add("england11");
        leg.Add("england12");
        leg.Add("france");
        leg.Add("france2");
        leg.Add("france3");
        leg.Add("germany");
        leg.Add("germany2");
        leg.Add("germany3");
        leg.Add("germany4");
        leg.Add("germany5");
        leg.Add("germany6");
        leg.Add("greece");
        leg.Add("greece2");
        leg.Add("holland");
        leg.Add("israel");
        leg.Add("italy");
        leg.Add("italy2");
        leg.Add("italy3");
        leg.Add("italy4");
        leg.Add("italy5");
        leg.Add("jordan");
        leg.Add("malta");
        leg.Add("morocco");
        leg.Add("northernireland");
        leg.Add("poland");
        leg.Add("portugal");
        leg.Add("portugal2");
        leg.Add("romania");
        leg.Add("russia");
        leg.Add("russia2");
        leg.Add("scotland");
        leg.Add("scotland2");
        leg.Add("scotland3");
        leg.Add("scotland4");
        leg.Add("serbia");
        leg.Add("slovenia");
        leg.Add("southafrica");
        leg.Add("spain");
        leg.Add("spain2");
        leg.Add("spain3");
        leg.Add("spain4");
        leg.Add("spain5");
        leg.Add("spain6");
        leg.Add("turkey");
        leg.Add("turkey2");
        leg.Add("wales");
        leg.Add("egypt");
            leg.Add("chile");
            leg.Add("chile2");
            leg.Add("costarica");
            leg.Add("czechrepublic");
            leg.Add("mexico");
            leg.Add("mexico2");
            leg.Add("holland2");
            leg.Add("paraguay");
            leg.Add("switzerland");
            #endregion

        }
            

        public void getDate(String league, string game,out string date, out string hour)
        {
            String prevGame;
            String team1 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[0];
            team1.Trim();
            team1 = team1.Substring(0, team1.Length - 1);
            String team2 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[1];
            team2.Trim();
            if (listBox2.SelectedIndex == 0)
            {
                prevGame = "";
            }
            else
            {
                prevGame = listBox2.Items[listBox2.SelectedIndex - 1].ToString();
            }
            date = "";
            hour = "";
            WebClient web = new WebClient();
            do
            {
                try
                {
                    webException = false;
                    String html = web.DownloadString("http://www.soccerstats.com/latest.asp?league=" + league + "&tid=a");
                    MatchCollection m1 = Regex.Matches(html, team1 + @"\r\n&nbsp;.+?<a href='(.+?)' title='", RegexOptions.Singleline);
                    foreach (Match m in m1)
                    {
                        string link = m.Groups[1].Value;
                        String html2 = web.DownloadString("http://www.soccerstats.com/" + link);
                        string matchID = link.Split('&')[1];
                        //                MatchCollection m2 = Regex.Matches(html2,matchID+ @".+?'>
                        //(Mon|Tue|Wed|Thu|Fri|Sat|Sun) (.+?): " + team1 + " -" + team2 , RegexOptions.Singleline);
                        //                foreach (Match n in m2)
                        //                {
                        //                    date = n.Groups[2].Value;
                        //                    try
                        //                    {
                        //                        date = date.Substring(date.Length - 6, 6);
                        //                        if (date.Substring(0, 1) == " ")
                        //                            date = date.Substring(1, 5);
                        //                    }
                        //                    catch (Exception)
                        //                    {
                        //                       date = date.Substring(0, 5); ;
                        //                    }
                        //                    break;
                        //                }
                        MatchCollection m2 = Regex.Matches(html2, @"<span title='"+game+@"'>\r\n<a href='.+?' style='display:block; text-decoration:none;' class='horiz'>\r\n<font color='gray'>\r\n(Mon|Tue|Wed|Thu|Fri|Sat|Sun) (.+?)\r\n</font>\r\n<br>\r\n<font size='2'>", RegexOptions.Singleline);
                        foreach (Match n in m2)
                        {
                            date = n.Groups[2].Value;
                            break;
                        }
                        break;
                    }
                }
                catch (WebException e)
                {                   
                        webException = true;                   
                }
            } while (webException == true);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
 //GETTING THE LIST OF GAMES
            List<string> games = new List<string>();

            WebClient web = new WebClient();
            String league = listBox1.GetItemText(listBox1.SelectedItem);
            do
            {
                try
                {
                    webException = false;
                    String html = web.DownloadString("http://www.soccerstats.com/latest.asp?league=" + league);
                    MatchCollection m1 = Regex.Matches(html, @"\n<a href='pmatch.asp\?league=.+?' title='(.+?) vs (.+?)\s?'", RegexOptions.Singleline);

                    foreach (Match m in m1)
                    {
                        string team1 = m.Groups[1].Value;
                        string team2 = m.Groups[2].Value;
                        string game = team1 + " vs " + team2;
                        games.Add(game);
                    }
                    listBox2.DataSource = games;
                }
                catch (WebException e2)
                {
                        webException = true;
                }

            } while (webException == true);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //GETTING THE PLAYING TEAMS FOR IN THE GAME
            textBox28.Clear();

            String game = listBox2.GetItemText(listBox2.SelectedItem);
            textBox1.Text = game;
            #region date
            String league = listBox1.GetItemText(listBox1.SelectedItem);
            string date = "", hour = "";
            getDate(league, game, out date, out hour);
            #endregion

            if (date == textBox54.Text)
            {
                String team1 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[0];
                String teamH = game.Split(new string[] { "vs" }, StringSplitOptions.None)[0];
                team1 = team1.Trim();
                teamH = teamH.Trim();
                if (teamH.Length > 12 && teamH.Length != 13)
                {
                    String temp = new String(teamH.Take(12).ToArray());
                    temp += ".";
                    teamH = temp;
                }
                String team2 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[1];
                String teamA = game.Split(new string[] { "vs" }, StringSplitOptions.None)[1];
                team2 = team2.Trim();
                teamA = teamA.Trim();
                if (teamA.Length > 12 && teamA.Length != 13)
                {
                    String temp = new String(teamA.Take(12).ToArray());
                    temp += ".";
                    teamA = temp;
                }


                List<string> statsH = new List<string>();
                List<string> statsA = new List<string>();
                List<string> statsTotal = new List<string>();
                List<string> statsForm = new List<string>();
                List<string> statsForm2 = new List<string>();
                List<string> statsForm3 = new List<string>();
                List<string> statsForm4 = new List<string>();
                List<string> statsFormA = new List<string>();
                List<string> statsForm2A = new List<string>();
                List<string> statsForm3A = new List<string>();
                List<string> statsForm4A = new List<string>();
                WebClient web = new WebClient();
                //String league = listBox1.GetItemText(listBox1.SelectedItem);
                do
                {
                    try
                    {
                        webException = false;
                        String html = web.DownloadString("http://www.soccerstats.com/table.asp?league=" + league + "&tid=d");
                        #region Home/Away
                        #region home
                        MatchCollection mHome = Regex.Matches(html,
                            @"target='_top'>" + team1 + @"\s?</a>&nbsp;
</td>
<td align='center'><font color='green'>
([0-9]\.[0-9][0-9])
</font></td>
<td align='center'><font color='red'>
([0-9]\.[0-9][0-9])
</font></td>
<td align='center'>
([0-9]\.[0-9][0-9])
</td>
<td>&nbsp;&nbsp;</td>
<td align='center'><font color='green'>
([0-9]\.[0-9][0-9])
</font></td>
<td align='center'><font color='red'>
([0-9]\.[0-9][0-9])
</td>
<td align='center'>
([0-9]\.[0-9][0-9])
</td>
<td>&nbsp;&nbsp;</td>
<td align='center'><font color='green'><b>
([0-9]\.[0-9][0-9])
</b></font></td>
<td align='center'><font color='red'><b>
([0-9]\.[0-9][0-9])
</b></font></td>", RegexOptions.Singleline);

                        foreach (Match m in mHome)
                        {
                            string stat1 = m.Groups[1].Value;
                            statsH.Add(stat1);
                            string stat2 = m.Groups[2].Value;
                            statsH.Add(stat2);
                            string stat5 = m.Groups[7].Value;
                            statsH.Add(stat5);
                            string stat6 = m.Groups[8].Value;
                            statsH.Add(stat6);
                        }
                        listBox3.DataSource = statsH;
                        #endregion
                        #region away
                        MatchCollection mAway = Regex.Matches(html,
                @"target='_top'>" + team2 + @"\s?</a>&nbsp;
</td>
<td align='center'><font color='green'>
([0-9]\.[0-9][0-9])
</font></td>
<td align='center'><font color='red'>
([0-9]\.[0-9][0-9])
</font></td>
<td align='center'>
([0-9]\.[0-9][0-9])
</td>
<td>&nbsp;&nbsp;</td>
<td align='center'><font color='green'>
([0-9]\.[0-9][0-9])
</font></td>
<td align='center'><font color='red'>
([0-9]\.[0-9][0-9])
</td>
<td align='center'>
([0-9]\.[0-9][0-9])
</td>
<td>&nbsp;&nbsp;</td>
<td align='center'><font color='green'><b>
([0-9]\.[0-9][0-9])
</b></font></td>
<td align='center'><font color='red'><b>
([0-9]\.[0-9][0-9])
</b></font></td>", RegexOptions.Singleline);

                        foreach (Match m in mAway)
                        {
                            string stat3 = m.Groups[4].Value;
                            statsA.Add(stat3);
                            string stat4 = m.Groups[5].Value;
                            statsA.Add(stat4);
                            string stat5 = m.Groups[7].Value;
                            statsA.Add(stat5);
                            string stat6 = m.Groups[8].Value;
                            statsA.Add(stat6);
                        }
                        listBox4.DataSource = statsA;
                        #endregion
                        #region total
                        html = web.DownloadString("http://www.soccerstats.com/latest.asp?league=" + league);
                        MatchCollection mTotal = Regex.Matches(html,
                            @"<td><b>([0-9]\.[0-9][0-9])</b></td>", RegexOptions.Singleline);

                        foreach (Match m in mTotal)
                        {
                            string stat1 = m.Groups[1].Value;
                            statsTotal.Add(stat1);
                            //string stat2 = m.Groups[3].Value;
                            //statsTotal.Add(stat2);

                        }
                        listBox5.DataSource = statsTotal;
                        #endregion
                        #region form4
                        String html2 = web.DownloadString("http://www.soccerstats.com/formtable.asp?league=" + league);

                        MatchCollection mFormH = Regex.Matches(html2, @"target='_top'>" + team1 + @"\s?</a>
</TD>
<td align='center'>
<font color='green'>
[0-9]*
</font>
</TD>
<td align='center'>
[0-9]*
</TD>
<td align='center'>
[0-9]*
</TD>
<td align='center'>
[0-9]*
</TD>
<td align='center'>
<font color='blue'>
([0-9]*)
</font>
</TD>
<td align='center'>
<font color='red'>
([0-9]*)
</font>", RegexOptions.Singleline);
                        foreach (Match m in mFormH)
                        {
                            string form = m.Groups[1].Value;
                            statsForm.Add(form);
                            form = m.Groups[2].Value;
                            statsForm2.Add(form);
                        }
                        listBox8.DataSource = statsForm;
                        listBox7.DataSource = statsForm2;
                        if (listBox8.Items.Count == 0)
                        {
                            MatchCollection mFormH2 = Regex.Matches(html2, @"target='_top'>" + team1 + @"\s?</a>
</TD>
<td align='center'>
<font color='green'>
[0-9]*
</font>
</TD>
<td align='center'>
[0-9]*
</TD>
<td align='center'>
[0-9]*
</TD>
<td align='center'>
[0-9]*
</TD>
<td align='center'>
<font color='blue'>
([0-9]*)
</font>
</TD>
<td align='center'>
<font color='red'>
([0-9]*)
</font>", RegexOptions.Singleline);
                            foreach (Match m in mFormH2)
                            {
                                string form = m.Groups[1].Value;
                                statsForm3.Add(form);
                                form = m.Groups[2].Value;
                                statsForm4.Add(form);
                            }
                            listBox8.DataSource = statsForm3;
                            listBox7.DataSource = statsForm4;
                        }

                        MatchCollection mFormA = Regex.Matches(html2, @"target='_top'>" + team2 + @"\s?</a>
</TD>
<td align='center'>
<font color='green'>
[0-9]*
</font>
</TD>
<td align='center'>
[0-9]*
</TD>
<td align='center'>
[0-9]*
</TD>
<td align='center'>
[0-9]*
</TD>
<td align='center'>
<font color='blue'>
([0-9]*)
</font>
</TD>
<td align='center'>
<font color='red'>
([0-9]*)
</font>", RegexOptions.Singleline);
                        foreach (Match m in mFormA)
                        {
                            string form = m.Groups[1].Value;
                            statsFormA.Add(form);
                            form = m.Groups[2].Value;
                            statsForm2A.Add(form);
                        }
                        listBox6.DataSource = statsFormA;
                        listBox9.DataSource = statsForm2A;
                        if (listBox6.Items.Count == 0)
                        {
                            MatchCollection mFormA2 = Regex.Matches(html2, @"target='_top'>" + team2 + @"\s?</a>
</TD>
<td align='center'>
<font color='green'>
[0-9]*
</font>
</TD>
<td align='center'>
[0-9]*
</TD>
<td align='center'>
[0-9]*
</TD>
<td align='center'>
[0-9]*
</TD>
<td align='center'>
<font color='blue'>
([0-9]*)
</font>
</TD>
<td align='center'>
<font color='red'>
([0-9]*)
</font>", RegexOptions.Singleline);
                            foreach (Match m in mFormA2)
                            {
                                string form = m.Groups[1].Value;
                                statsForm3A.Add(form);
                                form = m.Groups[2].Value;
                                statsForm4A.Add(form);
                            }
                            listBox6.DataSource = statsForm3A;
                            listBox9.DataSource = statsForm4A;
                        }
                        #endregion
                        #region form8

                        #endregion
                    }
                    catch (WebException e3)
                    {
                            webException = true;
                    }
                } while (webException==true);

             
                textBox1.AppendText("\r\n" + team1 + "\r\n" + team2);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        public void button3_Click(object sender, EventArgs e)
        {
            textBox27.Clear();
            textBox28.Clear();
                double goalsHFor = Convert.ToDouble(listBox3.Items[0].ToString());
                double goalsHForTotal = Convert.ToDouble(listBox3.Items[2].ToString());
                double goalsHAgainst = Convert.ToDouble(listBox3.Items[1].ToString());
                double goalsHAgainstTotal = Convert.ToDouble(listBox3.Items[3].ToString());
                double avgGoalsHFor = Convert.ToDouble(listBox5.Items[0].ToString());
                double goalsAFor = Convert.ToDouble(listBox4.Items[0].ToString());
                double goalsAForTtal = Convert.ToDouble(listBox4.Items[2].ToString());
                double goalsAAgainst = Convert.ToDouble(listBox4.Items[1].ToString());
                double goalsAAgainstTotal = Convert.ToDouble(listBox4.Items[3].ToString());
                double avgGoalsAFor = Convert.ToDouble(listBox5.Items[2].ToString());
                double teamHomePower = goalsHFor * goalsAAgainst / avgGoalsHFor;
                double teamAwayPower = goalsAFor * goalsHAgainst / avgGoalsAFor;
                double teamHomePowerTotal = goalsHForTotal * goalsAAgainstTotal / avgGoalsHFor;
                double teamAwayPowerTotal = goalsAForTtal * goalsHAgainstTotal / avgGoalsAFor;
                double goalsHForForm = Convert.ToDouble(listBox8.Items[2].ToString());
                goalsHForForm /= 4;
                double goalsHAgainstForm = Convert.ToDouble(listBox7.Items[2].ToString());
                goalsHAgainstForm /= 4;
                double goalsAForForm = Convert.ToDouble(listBox6.Items[4].ToString());
                goalsAForForm /= 4;
                double goalsAAgainstForm = Convert.ToDouble(listBox9.Items[4].ToString());
                goalsAAgainstForm /= 4;
                double teamHomePowerForm = goalsHForForm * goalsAAgainstForm / avgGoalsHFor;
                double teamAwayPowerForm = goalsAForForm * goalsHAgainstForm / avgGoalsAFor;
                double goalsHForForm8 = Convert.ToDouble(listBox8.Items[0].ToString());
                goalsHForForm8 /= 6;
                double goalsHAgainstForm8 = Convert.ToDouble(listBox7.Items[0].ToString());
                goalsHAgainstForm8 /= 6;
                double goalsAForForm8 = Convert.ToDouble(listBox6.Items[0].ToString());
                goalsAForForm8 /= 6;
                double goalsAAgainstForm8 = Convert.ToDouble(listBox9.Items[0].ToString());
                goalsAAgainstForm8 /= 6;
                double teamHomePowerForm8 = goalsHForForm8 * goalsAAgainstForm8 / avgGoalsHFor;
                double teamAwayPowerForm8 = goalsAForForm8 * goalsHAgainstForm8 / avgGoalsAFor;
            textBox1.Text = "Home power: " + teamHomePower.ToString() + Environment.NewLine + "Away power: " + teamAwayPower.ToString();
            textBox26.Text = "Home power: " + teamHomePowerTotal.ToString() + Environment.NewLine + "Away power: " + teamAwayPowerTotal.ToString();
            double result;

            #region 0
            result = (Math.Pow(teamHomePower, 0)) / (Factorial(0) * Math.Pow(Math.E, teamHomePower));
            textBox2.Text = result.ToString();
            result = (Math.Pow(teamAwayPower, 0)) / (Factorial(0) * Math.Pow(Math.E, teamAwayPower));
            textBox8.Text = result.ToString();
            result = (Math.Pow(teamHomePowerTotal, 0)) / (Factorial(0) * Math.Pow(Math.E, teamHomePowerTotal));
            textBox14.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerTotal, 0)) / (Factorial(0) * Math.Pow(Math.E, teamAwayPowerTotal));
            textBox20.Text = result.ToString();
            result = (Math.Pow(teamHomePowerForm, 0)) / (Factorial(0) * Math.Pow(Math.E, teamHomePowerForm));
            textBox29.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerForm, 0)) / (Factorial(0) * Math.Pow(Math.E, teamAwayPowerForm));
            textBox35.Text = result.ToString();
            result = (Math.Pow(teamHomePowerForm8, 0)) / (Factorial(0) * Math.Pow(Math.E, teamHomePowerForm8));
            textBox42.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerForm8, 0)) / (Factorial(0) * Math.Pow(Math.E, teamAwayPowerForm8));
            textBox48.Text = result.ToString();
            #endregion

            #region 1
            result = (Math.Pow(teamHomePower, 1)) / (Factorial(1) * Math.Pow(Math.E, teamHomePower));
            textBox3.Text = result.ToString();
            result = (Math.Pow(teamAwayPower, 1)) / (Factorial(1) * Math.Pow(Math.E, teamAwayPower));
            textBox9.Text = result.ToString();
            result = (Math.Pow(teamHomePowerTotal, 1)) / (Factorial(1) * Math.Pow(Math.E, teamHomePowerTotal));
            textBox15.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerTotal, 1)) / (Factorial(1) * Math.Pow(Math.E, teamAwayPowerTotal));
            textBox21.Text = result.ToString();
            result = (Math.Pow(teamHomePowerForm, 1)) / (Factorial(1) * Math.Pow(Math.E, teamHomePowerForm));
            textBox30.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerForm, 1)) / (Factorial(1) * Math.Pow(Math.E, teamAwayPowerForm));
            textBox36.Text = result.ToString();
            result = (Math.Pow(teamHomePowerForm8, 1)) / (Factorial(1) * Math.Pow(Math.E, teamHomePowerForm8));
            textBox43.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerForm8, 1)) / (Factorial(1) * Math.Pow(Math.E, teamAwayPowerForm8));
            textBox49.Text = result.ToString();
            #endregion

            #region 2
            result = (Math.Pow(teamHomePower, 2)) / (Factorial(2) * Math.Pow(Math.E, teamHomePower));
            textBox4.Text = result.ToString();
            result = (Math.Pow(teamAwayPower, 2)) / (Factorial(2) * Math.Pow(Math.E, teamAwayPower));
            textBox10.Text = result.ToString();
            result = (Math.Pow(teamHomePowerTotal, 2)) / (Factorial(2) * Math.Pow(Math.E, teamHomePowerTotal));
            textBox16.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerTotal, 2)) / (Factorial(2) * Math.Pow(Math.E, teamAwayPowerTotal));
            textBox22.Text = result.ToString();
            result = (Math.Pow(teamHomePowerForm, 2)) / (Factorial(2) * Math.Pow(Math.E, teamHomePowerForm));
            textBox31.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerForm, 2)) / (Factorial(2) * Math.Pow(Math.E, teamAwayPowerForm));
            textBox37.Text = result.ToString();
            result = (Math.Pow(teamHomePowerForm8, 2)) / (Factorial(2) * Math.Pow(Math.E, teamHomePowerForm8));
            textBox44.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerForm8, 2)) / (Factorial(2) * Math.Pow(Math.E, teamAwayPowerForm8));
            textBox50.Text = result.ToString();
            #endregion

            #region 3
            result = (Math.Pow(teamHomePower, 3)) / (Factorial(3) * Math.Pow(Math.E, teamHomePower));
            textBox5.Text = result.ToString();
            result = (Math.Pow(teamAwayPower, 3)) / (Factorial(3) * Math.Pow(Math.E, teamAwayPower));
            textBox11.Text = result.ToString();
            result = (Math.Pow(teamHomePowerTotal, 3)) / (Factorial(3) * Math.Pow(Math.E, teamHomePowerTotal));
            textBox17.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerTotal, 3)) / (Factorial(3) * Math.Pow(Math.E, teamAwayPowerTotal));
            textBox23.Text = result.ToString();
            result = (Math.Pow(teamHomePowerForm, 3)) / (Factorial(3) * Math.Pow(Math.E, teamHomePowerForm));
            textBox32.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerForm, 3)) / (Factorial(3) * Math.Pow(Math.E, teamAwayPowerForm));
            textBox38.Text = result.ToString();
            result = (Math.Pow(teamHomePowerForm8, 3)) / (Factorial(3) * Math.Pow(Math.E, teamHomePowerForm8));
            textBox45.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerForm8, 3)) / (Factorial(3) * Math.Pow(Math.E, teamAwayPowerForm8));
            textBox51.Text = result.ToString();
            #endregion

            #region 4
            result = (Math.Pow(teamHomePower, 4)) / (Factorial(4) * Math.Pow(Math.E, teamHomePower));
            textBox6.Text = result.ToString();
            result = (Math.Pow(teamAwayPower, 4)) / (Factorial(4) * Math.Pow(Math.E, teamAwayPower));
            textBox12.Text = result.ToString();
            result = (Math.Pow(teamHomePowerTotal, 4)) / (Factorial(4) * Math.Pow(Math.E, teamHomePowerTotal));
            textBox18.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerTotal, 4)) / (Factorial(4) * Math.Pow(Math.E, teamAwayPowerTotal));
            textBox24.Text = result.ToString();
            result = (Math.Pow(teamHomePowerForm, 4)) / (Factorial(4) * Math.Pow(Math.E, teamHomePowerForm));
            textBox33.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerForm, 4)) / (Factorial(4) * Math.Pow(Math.E, teamAwayPowerForm));
            textBox39.Text = result.ToString();
            result = (Math.Pow(teamHomePowerForm8, 4)) / (Factorial(4) * Math.Pow(Math.E, teamHomePowerForm8));
            textBox46.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerForm8, 4)) / (Factorial(4) * Math.Pow(Math.E, teamAwayPowerForm8));
            textBox52.Text = result.ToString();
            #endregion

            #region 5
            result = (Math.Pow(teamHomePower, 5)) / (Factorial(5) * Math.Pow(Math.E, teamHomePower));
            textBox7.Text = result.ToString();
            result = (Math.Pow(teamAwayPower, 5)) / (Factorial(5) * Math.Pow(Math.E, teamAwayPower));
            textBox13.Text = result.ToString();
            result = (Math.Pow(teamHomePowerTotal, 5)) / (Factorial(5) * Math.Pow(Math.E, teamHomePowerTotal));
            textBox19.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerTotal, 5)) / (Factorial(5) * Math.Pow(Math.E, teamAwayPowerTotal));
            textBox25.Text = result.ToString();
            result = (Math.Pow(teamHomePowerForm, 5)) / (Factorial(5) * Math.Pow(Math.E, teamHomePowerForm));
            textBox34.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerForm, 5)) / (Factorial(5) * Math.Pow(Math.E, teamAwayPowerForm));
            textBox40.Text = result.ToString();
            result = (Math.Pow(teamHomePowerForm8, 5)) / (Factorial(5) * Math.Pow(Math.E, teamHomePowerForm8));
            textBox47.Text = result.ToString();
            result = (Math.Pow(teamAwayPowerForm8, 5)) / (Factorial(5) * Math.Pow(Math.E, teamAwayPowerForm8));
            textBox53.Text = result.ToString();
            #endregion
            double[,] distribution = new double[,] {
                {Convert.ToDouble(textBox2.Text),Convert.ToDouble(textBox3.Text),Convert.ToDouble(textBox4.Text),Convert.ToDouble(textBox5.Text),Convert.ToDouble(textBox6.Text),Convert.ToDouble(textBox7.Text)  },
                {Convert.ToDouble(textBox8.Text),Convert.ToDouble(textBox9.Text),Convert.ToDouble(textBox10.Text),Convert.ToDouble(textBox11.Text),Convert.ToDouble(textBox12.Text),Convert.ToDouble(textBox13.Text)  }
            };
            double[,] distribution2 = new double[,] {
                {Convert.ToDouble(textBox14.Text),Convert.ToDouble(textBox15.Text),Convert.ToDouble(textBox16.Text),Convert.ToDouble(textBox17.Text),Convert.ToDouble(textBox18.Text),Convert.ToDouble(textBox19.Text)  },
                {Convert.ToDouble(textBox20.Text),Convert.ToDouble(textBox21.Text),Convert.ToDouble(textBox22.Text),Convert.ToDouble(textBox23.Text),Convert.ToDouble(textBox24.Text),Convert.ToDouble(textBox25.Text)  }
            };

            double[,] distribution3 = new double[,] {
                {Convert.ToDouble(textBox29.Text),Convert.ToDouble(textBox30.Text),Convert.ToDouble(textBox31.Text),Convert.ToDouble(textBox32.Text),Convert.ToDouble(textBox33.Text),Convert.ToDouble(textBox34.Text)  },
                {Convert.ToDouble(textBox35.Text),Convert.ToDouble(textBox36.Text),Convert.ToDouble(textBox37.Text),Convert.ToDouble(textBox38.Text),Convert.ToDouble(textBox39.Text),Convert.ToDouble(textBox40.Text)  }
            };

            double[,] distribution4 = new double[,] {
                {Convert.ToDouble(textBox42.Text),Convert.ToDouble(textBox43.Text),Convert.ToDouble(textBox44.Text),Convert.ToDouble(textBox45.Text),Convert.ToDouble(textBox46.Text),Convert.ToDouble(textBox47.Text)  },
                {Convert.ToDouble(textBox48.Text),Convert.ToDouble(textBox49.Text),Convert.ToDouble(textBox50.Text),Convert.ToDouble(textBox51.Text),Convert.ToDouble(textBox52.Text),Convert.ToDouble(textBox53.Text)  }
            };
            #region results
            double outcome1, outcomeX, outcome2, GG, NG, Over1, Over2, Over3, Under1, Under2, Under3;
            outcome1 = distribution[0, 1] * distribution[1, 0] + distribution[0, 2] * (distribution[1, 0] + distribution[1, 1]) + distribution[0, 3] * (distribution[1, 0] + distribution[1, 1] + distribution[1, 2]) + distribution[0, 4] * (distribution[1, 0] + distribution[1, 1] + distribution[1, 2] + distribution[1, 3]) + distribution[0, 5] * (distribution[1, 0] + distribution[1, 1] + distribution[1, 2] + distribution[1, 3] + distribution[1, 4]);
            outcomeX = distribution[0, 0] * distribution[1, 0] + distribution[1, 1] * distribution[0, 1] + distribution[0, 2] * distribution[1, 2] + distribution[0, 3] * distribution[1, 3] + distribution[0, 4] * distribution[1, 4];
            outcome2 = distribution[1, 1] * distribution[0, 0] + distribution[1, 2] * (distribution[0, 0] + distribution[0, 1]) + distribution[1, 3] * (distribution[0, 0] + distribution[0, 1] + distribution[0, 2]) + distribution[1, 4] * (distribution[0, 0] + distribution[0, 1] + distribution[0, 2] + distribution[0, 3]) + distribution[1, 5] * (distribution[0, 0] + distribution[0, 1] + distribution[0, 2] + distribution[0, 3] + distribution[0, 4]);
            GG = (distribution[0, 1] + distribution[0, 2] + distribution[0, 3] + distribution[0, 4] + distribution[0, 5]) * (distribution[1, 1] + distribution[1, 2] + distribution[1, 3] + distribution[1, 4] + distribution[1, 5]);
            NG = distribution[0, 0] * distribution[1, 0] + distribution[0, 0] * (distribution[1, 1] + distribution[1, 2] + distribution[1, 3] + distribution[1, 4] + distribution[1, 5]) + distribution[1, 0] * (distribution[0, 1] + distribution[0, 2] + distribution[0, 3] + distribution[0, 4] + distribution[0, 5]);
            Over1 = (distribution[0, 2] + distribution[0, 3] + distribution[0, 4] + distribution[0, 5]) * (distribution[1, 0] + distribution[1, 1] + distribution[1, 2] + distribution[1, 3] + distribution[1, 4] + distribution[1, 5]) + distribution[0, 1] * (distribution[1, 1] + distribution[1, 2] + distribution[1, 3] + distribution[1, 4] + distribution[1, 5]) + distribution[0, 0] * (distribution[1, 2] + distribution[1, 3] + distribution[1, 4] + distribution[1, 5]);
            Under1 = distribution[0, 0] * (distribution[1, 0] + distribution[1, 1]) + distribution[0, 1] * distribution[1, 0];
            Over2 = (distribution[0, 3] + distribution[0, 4] + distribution[0, 5]) * (distribution[1, 0] + distribution[1, 1] + distribution[1, 2] + distribution[1, 3] + distribution[1, 4] + distribution[1, 5]) + distribution[0, 2] * (distribution[1, 1] + distribution[1, 2] + distribution[1, 3] + distribution[1, 4] + distribution[1, 5]) + distribution[0, 1] * (distribution[1, 2] + distribution[1, 3] + distribution[1, 4] + distribution[1, 5]) + distribution[0, 0] * (distribution[1, 3] + distribution[1, 4] + distribution[1, 5]);
            Under2 = distribution[0, 0] * (distribution[1, 0] + distribution[1, 1] + distribution[1, 2]) + distribution[0, 1] * (distribution[1, 0] + distribution[1, 1]) + distribution[0, 2] * distribution[1, 0];
            Over3 = (distribution[0, 4] + distribution[0, 5]) * (distribution[1, 0] + distribution[1, 1] + distribution[1, 2] + distribution[1, 3] + distribution[1, 4] + distribution[1, 5]) + distribution[0, 3] * (distribution[1, 1] + distribution[1, 2] + distribution[1, 3] + distribution[1, 4] + distribution[1, 5]) + distribution[0, 2] * (distribution[1, 2] + distribution[1, 3] + distribution[1, 4] + distribution[1, 5]) + distribution[0, 1] * (distribution[1, 3] + distribution[1, 4] + distribution[1, 5]) + distribution[0, 0] * (distribution[1, 4] + distribution[1, 5]);
            Under3 = distribution[0, 0] * (distribution[1, 0] + distribution[1, 1] + distribution[1, 2] + distribution[1, 3]) + distribution[0, 1] * (distribution[1, 0] + distribution[1, 1] + distribution[1, 2]) + distribution[0, 2] * (distribution[1, 0] + distribution[1, 1]) + distribution[0, 3] * distribution[1, 0];
            textBox1.Text = "Home: " + outcome1.ToString() + Environment.NewLine + "X: " + outcomeX + Environment.NewLine + "Away: " + outcome2 + Environment.NewLine + "GG: " + GG + Environment.NewLine + "NG: " + NG+Environment.NewLine+"Over 1.5: "+Over1+Environment.NewLine+"Under 1.5: "+Under1+Environment.NewLine+"Over 2.5: "+Over2+Environment.NewLine+"Under 2.5: "+Under2+Environment.NewLine+"Over 3.5: "+Over3+Environment.NewLine+"Under 3.5"+Under3;

            double S_outcome1, S_outcomeX, S_outcome2, S_GG, S_NG, S_Over1, S_Over2, S_Over3, S_Under1, S_Under2, S_Under3;
            S_outcome1 = distribution2[0, 1] * distribution2[1, 0] + distribution2[0, 2] * (distribution2[1, 0] + distribution2[1, 1]) + distribution2[0, 3] * (distribution2[1, 0] + distribution2[1, 1] + distribution2[1, 2]) + distribution2[0, 4] * (distribution2[1, 0] + distribution2[1, 1] + distribution2[1, 2] + distribution2[1, 3]) + distribution2[0, 5] * (distribution2[1, 0] + distribution2[1, 1] + distribution2[1, 2] + distribution2[1, 3] + distribution2[1, 4]);
            S_outcomeX = distribution2[0, 0] * distribution2[1, 0] + distribution2[1, 1] * distribution2[0, 1] + distribution2[0, 2] * distribution2[1, 2] + distribution2[0, 3] * distribution2[1, 3] + distribution2[0, 4] * distribution2[1, 4];
            S_outcome2 = distribution2[1, 1] * distribution2[0, 0] + distribution2[1, 2] * (distribution2[0, 0] + distribution2[0, 1]) + distribution2[1, 3] * (distribution2[0, 0] + distribution2[0, 1] + distribution2[0, 2]) + distribution2[1, 4] * (distribution2[0, 0] + distribution2[0, 1] + distribution2[0, 2] + distribution2[0, 3]) + distribution2[1, 5] * (distribution2[0, 0] + distribution2[0, 1] + distribution2[0, 2] + distribution2[0, 3] + distribution2[0, 4]);
            S_GG = (distribution2[0, 1] + distribution2[0, 2] + distribution2[0, 3] + distribution2[0, 4] + distribution2[0, 5]) * (distribution2[1, 1] + distribution2[1, 2] + distribution2[1, 3] + distribution2[1, 4] + distribution2[1, 5]);
            S_NG = distribution2[0, 0] * distribution2[1, 0] + distribution2[0, 0] * (distribution2[1, 1] + distribution2[1, 2] + distribution2[1, 3] + distribution2[1, 4] + distribution2[1, 5]) + distribution2[1, 0] * (distribution2[0, 1] + distribution2[0, 2] + distribution2[0, 3] + distribution2[0, 4] + distribution2[0, 5]);
            S_Over1 = (distribution2[0, 2] + distribution2[0, 3] + distribution2[0, 4] + distribution2[0, 5]) * (distribution2[1, 0] + distribution2[1, 1] + distribution2[1, 2] + distribution2[1, 3] + distribution2[1, 4] + distribution2[1, 5]) + distribution2[0, 1] * (distribution2[1, 1] + distribution2[1, 2] + distribution2[1, 3] + distribution2[1, 4] + distribution2[1, 5]) + distribution2[0, 0] * (distribution2[1, 2] + distribution2[1, 3] + distribution2[1, 4] + distribution2[1, 5]);
            S_Under1 = distribution2[0, 0] * (distribution2[1, 0] + distribution2[1, 1]) + distribution2[0, 1] * distribution2[1, 0];
            S_Over2 = (distribution2[0, 3] + distribution2[0, 4] + distribution2[0, 5]) * (distribution2[1, 0] + distribution2[1, 1] + distribution2[1, 2] + distribution2[1, 3] + distribution2[1, 4] + distribution2[1, 5]) + distribution2[0, 2] * (distribution2[1, 1] + distribution2[1, 2] + distribution2[1, 3] + distribution2[1, 4] + distribution2[1, 5]) + distribution2[0, 1] * (distribution2[1, 2] + distribution2[1, 3] + distribution2[1, 4] + distribution2[1, 5]) + distribution2[0, 0] * (distribution2[1, 3] + distribution2[1, 4] + distribution2[1, 5]);
            S_Under2 = distribution2[0, 0] * (distribution2[1, 0] + distribution2[1, 1] + distribution2[1, 2]) + distribution2[0, 1] * (distribution2[1, 0] + distribution2[1, 1]) + distribution2[0, 2] * distribution2[1, 0];
            S_Over3 = (distribution2[0, 4] + distribution2[0, 5]) * (distribution2[1, 0] + distribution2[1, 1] + distribution2[1, 2] + distribution2[1, 3] + distribution2[1, 4] + distribution2[1, 5]) + distribution2[0, 3] * (distribution2[1, 1] + distribution2[1, 2] + distribution2[1, 3] + distribution2[1, 4] + distribution2[1, 5]) + distribution2[0, 2] * (distribution2[1, 2] + distribution2[1, 3] + distribution2[1, 4] + distribution2[1, 5]) + distribution2[0, 1] * (distribution2[1, 3] + distribution2[1, 4] + distribution2[1, 5]) + distribution2[0, 0] * (distribution2[1, 4] + distribution2[1, 5]);
            S_Under3 = distribution2[0, 0] * (distribution2[1, 0] + distribution2[1, 1] + distribution2[1, 2] + distribution2[1, 3]) + distribution2[0, 1] * (distribution2[1, 0] + distribution2[1, 1] + distribution2[1, 2]) + distribution2[0, 2] * (distribution2[1, 0] + distribution2[1, 1]) + distribution2[0, 3] * distribution2[1, 0];
            textBox26.Text = "Home: " + S_outcome1.ToString() + Environment.NewLine + "X: " + S_outcomeX + Environment.NewLine + "Away: " + S_outcome2 + Environment.NewLine + "GG: " + S_GG + Environment.NewLine + "NG: " + S_NG + Environment.NewLine + "Over 1.5: " + S_Over1 + Environment.NewLine + "Under 1.5: " + S_Under1 + Environment.NewLine + "Over 2.5: " + S_Over2 + Environment.NewLine + "Under 2.5: " + S_Under2 + Environment.NewLine + "Over 3.5: " + S_Over3 + Environment.NewLine + "Under 3.5" + S_Under3;

            double F_outcome1, F_outcomeX, F_outcome2, F_GG, F_NG, F_Over1, F_Over2, F_Over3, F_Under1, F_Under2, F_Under3;
            F_outcome1 = distribution3[0, 1] * distribution3[1, 0] + distribution3[0, 2] * (distribution3[1, 0] + distribution3[1, 1]) + distribution3[0, 3] * (distribution3[1, 0] + distribution3[1, 1] + distribution3[1, 2]) + distribution3[0, 4] * (distribution3[1, 0] + distribution3[1, 1] + distribution3[1, 2] + distribution3[1, 3]) + distribution3[0, 5] * (distribution3[1, 0] + distribution3[1, 1] + distribution3[1, 2] + distribution3[1, 3] + distribution3[1, 4]);
            F_outcomeX = distribution3[0, 0] * distribution3[1, 0] + distribution3[1, 1] * distribution3[0, 1] + distribution3[0, 2] * distribution3[1, 2] + distribution3[0, 3] * distribution3[1, 3] + distribution3[0, 4] * distribution3[1, 4];
            F_outcome2 = distribution3[1, 1] * distribution3[0, 0] + distribution3[1, 2] * (distribution3[0, 0] + distribution3[0, 1]) + distribution3[1, 3] * (distribution3[0, 0] + distribution3[0, 1] + distribution3[0, 2]) + distribution3[1, 4] * (distribution3[0, 0] + distribution3[0, 1] + distribution3[0, 2] + distribution3[0, 3]) + distribution3[1, 5] * (distribution3[0, 0] + distribution3[0, 1] + distribution3[0, 2] + distribution3[0, 3] + distribution3[0, 4]);
            F_GG = (distribution3[0, 1] + distribution3[0, 2] + distribution3[0, 3] + distribution3[0, 4] + distribution3[0, 5]) * (distribution3[1, 1] + distribution3[1, 2] + distribution3[1, 3] + distribution3[1, 4] + distribution3[1, 5]);
            F_NG = distribution3[0, 0] * distribution3[1, 0] + distribution3[0, 0] * (distribution3[1, 1] + distribution3[1, 2] + distribution3[1, 3] + distribution3[1, 4] + distribution3[1, 5]) + distribution3[1, 0] * (distribution3[0, 1] + distribution3[0, 2] + distribution3[0, 3] + distribution3[0, 4] + distribution3[0, 5]);
            F_Over1 = (distribution3[0, 2] + distribution3[0, 3] + distribution3[0, 4] + distribution3[0, 5]) * (distribution3[1, 0] + distribution3[1, 1] + distribution3[1, 2] + distribution3[1, 3] + distribution3[1, 4] + distribution3[1, 5]) + distribution3[0, 1] * (distribution3[1, 1] + distribution3[1, 2] + distribution3[1, 3] + distribution3[1, 4] + distribution3[1, 5]) + distribution3[0, 0] * (distribution3[1, 2] + distribution3[1, 3] + distribution3[1, 4] + distribution3[1, 5]);
            F_Under1 = distribution3[0, 0] * (distribution3[1, 0] + distribution3[1, 1]) + distribution3[0, 1] * distribution3[1, 0];
            F_Over2 = (distribution3[0, 3] + distribution3[0, 4] + distribution3[0, 5]) * (distribution3[1, 0] + distribution3[1, 1] + distribution3[1, 2] + distribution3[1, 3] + distribution3[1, 4] + distribution3[1, 5]) + distribution3[0, 2] * (distribution3[1, 1] + distribution3[1, 2] + distribution3[1, 3] + distribution3[1, 4] + distribution3[1, 5]) + distribution3[0, 1] * (distribution3[1, 2] + distribution3[1, 3] + distribution3[1, 4] + distribution3[1, 5]) + distribution3[0, 0] * (distribution3[1, 3] + distribution3[1, 4] + distribution3[1, 5]);
            F_Under2 = distribution3[0, 0] * (distribution3[1, 0] + distribution3[1, 1] + distribution3[1, 2]) + distribution3[0, 1] * (distribution3[1, 0] + distribution3[1, 1]) + distribution3[0, 2] * distribution3[1, 0];
            F_Over3 = (distribution3[0, 4] + distribution3[0, 5]) * (distribution3[1, 0] + distribution3[1, 1] + distribution3[1, 2] + distribution3[1, 3] + distribution3[1, 4] + distribution3[1, 5]) + distribution3[0, 3] * (distribution3[1, 1] + distribution3[1, 2] + distribution3[1, 3] + distribution3[1, 4] + distribution3[1, 5]) + distribution3[0, 2] * (distribution3[1, 2] + distribution3[1, 3] + distribution3[1, 4] + distribution3[1, 5]) + distribution3[0, 1] * (distribution3[1, 3] + distribution3[1, 4] + distribution3[1, 5]) + distribution3[0, 0] * (distribution3[1, 4] + distribution3[1, 5]);
            F_Under3 = distribution3[0, 0] * (distribution3[1, 0] + distribution3[1, 1] + distribution3[1, 2] + distribution3[1, 3]) + distribution3[0, 1] * (distribution3[1, 0] + distribution3[1, 1] + distribution3[1, 2]) + distribution3[0, 2] * (distribution3[1, 0] + distribution3[1, 1]) + distribution3[0, 3] * distribution3[1, 0];
            textBox26.Text = "Home: " + F_outcome1.ToString() + Environment.NewLine + "X: " + F_outcomeX + Environment.NewLine + "Away: " + F_outcome2 + Environment.NewLine + "GG: " + F_GG + Environment.NewLine + "NG: " + F_NG + Environment.NewLine + "Over 1.5: " + F_Over1 + Environment.NewLine + "Under 1.5: " + F_Under1 + Environment.NewLine + "Over 2.5: " + F_Over2 + Environment.NewLine + "Under 2.5: " + F_Under2 + Environment.NewLine + "Over 3.5: " + F_Over3 + Environment.NewLine + "Under 3.5" + F_Under3;

            double F8_outcome1, F8_outcomeX, F8_outcome2, F8_GG, F8_NG, F8_Over1, F8_Over2, F8_Over3, F8_Under1, F8_Under2, F8_Under3;
            F8_outcome1 = distribution4[0, 1] * distribution4[1, 0] + distribution4[0, 2] * (distribution4[1, 0] + distribution4[1, 1]) + distribution4[0, 3] * (distribution4[1, 0] + distribution4[1, 1] + distribution4[1, 2]) + distribution4[0, 4] * (distribution4[1, 0] + distribution4[1, 1] + distribution4[1, 2] + distribution4[1, 3]) + distribution4[0, 5] * (distribution4[1, 0] + distribution4[1, 1] + distribution4[1, 2] + distribution4[1, 3] + distribution4[1, 4]);
            F8_outcomeX = distribution4[0, 0] * distribution4[1, 0] + distribution4[1, 1] * distribution4[0, 1] + distribution4[0, 2] * distribution4[1, 2] + distribution4[0, 3] * distribution4[1, 3] + distribution4[0, 4] * distribution4[1, 4];
            F8_outcome2 = distribution4[1, 1] * distribution4[0, 0] + distribution4[1, 2] * (distribution4[0, 0] + distribution4[0, 1]) + distribution4[1, 3] * (distribution4[0, 0] + distribution4[0, 1] + distribution4[0, 2]) + distribution4[1, 4] * (distribution4[0, 0] + distribution4[0, 1] + distribution4[0, 2] + distribution4[0, 3]) + distribution4[1, 5] * (distribution4[0, 0] + distribution4[0, 1] + distribution4[0, 2] + distribution4[0, 3] + distribution4[0, 4]);
            F8_GG = (distribution4[0, 1] + distribution4[0, 2] + distribution4[0, 3] + distribution4[0, 4] + distribution4[0, 5]) * (distribution4[1, 1] + distribution4[1, 2] + distribution4[1, 3] + distribution4[1, 4] + distribution4[1, 5]);
            F8_NG = distribution4[0, 0] * distribution4[1, 0] + distribution4[0, 0] * (distribution4[1, 1] + distribution4[1, 2] + distribution4[1, 3] + distribution4[1, 4] + distribution4[1, 5]) + distribution4[1, 0] * (distribution4[0, 1] + distribution4[0, 2] + distribution4[0, 3] + distribution4[0, 4] + distribution4[0, 5]);
            F8_Over1 = (distribution4[0, 2] + distribution4[0, 3] + distribution4[0, 4] + distribution4[0, 5]) * (distribution4[1, 0] + distribution4[1, 1] + distribution4[1, 2] + distribution4[1, 3] + distribution4[1, 4] + distribution4[1, 5]) + distribution4[0, 1] * (distribution4[1, 1] + distribution4[1, 2] + distribution4[1, 3] + distribution4[1, 4] + distribution4[1, 5]) + distribution4[0, 0] * (distribution4[1, 2] + distribution4[1, 3] + distribution4[1, 4] + distribution4[1, 5]);
            F8_Under1 = distribution4[0, 0] * (distribution4[1, 0] + distribution4[1, 1]) + distribution4[0, 1] * distribution4[1, 0];
            F8_Over2 = (distribution4[0, 3] + distribution4[0, 4] + distribution4[0, 5]) * (distribution4[1, 0] + distribution4[1, 1] + distribution4[1, 2] + distribution4[1, 3] + distribution4[1, 4] + distribution4[1, 5]) + distribution4[0, 2] * (distribution4[1, 1] + distribution4[1, 2] + distribution4[1, 3] + distribution4[1, 4] + distribution4[1, 5]) + distribution4[0, 1] * (distribution4[1, 2] + distribution4[1, 3] + distribution4[1, 4] + distribution4[1, 5]) + distribution4[0, 0] * (distribution4[1, 3] + distribution4[1, 4] + distribution4[1, 5]);
            F8_Under2 = distribution4[0, 0] * (distribution4[1, 0] + distribution4[1, 1] + distribution4[1, 2]) + distribution4[0, 1] * (distribution4[1, 0] + distribution4[1, 1]) + distribution4[0, 2] * distribution4[1, 0];
            F8_Over3 = (distribution4[0, 4] + distribution4[0, 5]) * (distribution4[1, 0] + distribution4[1, 1] + distribution4[1, 2] + distribution4[1, 3] + distribution4[1, 4] + distribution4[1, 5]) + distribution4[0, 3] * (distribution4[1, 1] + distribution4[1, 2] + distribution4[1, 3] + distribution4[1, 4] + distribution4[1, 5]) + distribution4[0, 2] * (distribution4[1, 2] + distribution4[1, 3] + distribution4[1, 4] + distribution4[1, 5]) + distribution4[0, 1] * (distribution4[1, 3] + distribution4[1, 4] + distribution4[1, 5]) + distribution4[0, 0] * (distribution4[1, 4] + distribution4[1, 5]);
            F8_Under3 = distribution4[0, 0] * (distribution4[1, 0] + distribution4[1, 1] + distribution4[1, 2] + distribution4[1, 3]) + distribution4[0, 1] * (distribution4[1, 0] + distribution4[1, 1] + distribution4[1, 2]) + distribution4[0, 2] * (distribution3[1, 0] + distribution3[1, 1]) + distribution3[0, 3] * distribution3[1, 0];
            textBox26.Text = "Home: " + F8_outcome1.ToString() + Environment.NewLine + "X: " + F8_outcomeX + Environment.NewLine + "Away: " + F8_outcome2 + Environment.NewLine + "GG: " + F8_GG + Environment.NewLine + "NG: " + F8_NG + Environment.NewLine + "Over 1.5: " + F8_Over1 + Environment.NewLine + "Under 1.5: " + F8_Under1 + Environment.NewLine + "Over 2.5: " + F8_Over2 + Environment.NewLine + "Under 2.5: " + F8_Under2 + Environment.NewLine + "Over 3.5: " + F8_Over3 + Environment.NewLine + "Under 3.5" + F8_Under3;

            #endregion
            #endregion
            #region Finalresult
            double coeff1, coeff2;
            if(outcome1>0.7 && S_outcome1>0.7)
            {
                coeff1 = 1 / outcome1;
                coeff2 = 1 / S_outcome1;
                textBox27.AppendText("1: "+coeff1+"; "+coeff2+Environment.NewLine);
                if(F_outcome1>0.7 && F8_outcome1>0.7)
                {
                    textBox28.AppendText("1: " + 1 / F_outcome1 +"; " + 1/F8_outcome1+ Environment.NewLine);
                }
            }
            if (outcomeX > 0.7 && S_outcomeX > 0.7)
            {
                coeff1 = 1 / outcomeX;
                coeff2 = 1 / S_outcomeX;
                textBox27.AppendText("X: " + coeff1 + "; " + coeff2 + Environment.NewLine);
                if (F_outcomeX > 0.7 && F8_outcomeX>0.7)
                {
                    textBox28.AppendText("X: " + 1 / F_outcomeX + "; " + 1 / F8_outcomeX + Environment.NewLine);
                }
            }
            if (outcome2 > 0.7 && S_outcome2 > 0.7)
            {
                coeff1 = 1 / outcome2;
                coeff2 = 1 / S_outcome2;
                textBox27.AppendText("2: " + coeff1 + "; " + coeff2 + Environment.NewLine);
                if (F_outcome2 > 0.7 && F8_outcome2>0.7)
                {
                    textBox28.AppendText("2: " + 1 / F_outcome2 + "; " + 1 / F8_outcome2 + Environment.NewLine);
                }
            }
            if (GG > 0.7 && S_GG > 0.7)
            {
                coeff1 = 1 / GG;
                coeff2 = 1 / S_GG;
                textBox27.AppendText("GG: " + coeff1 + "; " + coeff2 + Environment.NewLine);
                if (F_GG > 0.7 && F8_GG>0.7)
                {
                    textBox28.AppendText("GG: " + 1 / F_GG + "; " + 1 / F8_GG+ Environment.NewLine);
                }
            }
            if (NG > 0.7 && S_NG > 0.7)
            {
                coeff1 = 1 / NG;
                coeff2 = 1 / S_NG;
                textBox27.AppendText("NG: " + coeff1 + "; " + coeff2 + Environment.NewLine);
                if (F_NG > 0.7 && F8_NG>0.7)
                {
                    textBox28.AppendText("NG: " + 1 / F_NG + "; " + 1 / F8_NG+ Environment.NewLine);
                }
            }
            if (Over1 > 0.7 && S_Over1 > 0.7)
            {
                coeff1 = 1 / Over1;
                coeff2 = 1 / S_Over1;
                textBox27.AppendText("Over 1.5: " + coeff1 + "; " + coeff2 + Environment.NewLine);
                if (F_Over1> 0.7 && F8_Over1 > 0.7)
                {
                    textBox28.AppendText("Over 1.5: " + 1 / F_Over1 + "; " + 1 / F8_Over1 + Environment.NewLine);
                }
            }
            if (Under1 > 0.7 && S_Under1 > 0.7)
            {
                coeff1 = 1 / Under1;
                coeff2 = 1 / S_Under1;
                textBox27.AppendText("Under 1.5: " + coeff1 + "; " + coeff2 + Environment.NewLine);
                if (F_Under1 > 0.7 && F8_Under1 > 0.7)
                {
                    textBox28.AppendText("Under 1.5: " + 1 / F_Under1 + "; " + 1 / F8_Under1 + Environment.NewLine);
                }
            }
            if (Over2 > 0.7 && S_Over2 > 0.7)
            {
                coeff1 = 1 / Over2;
                coeff2 = 1 / S_Over2;
                textBox27.AppendText("Over 2.5: " + coeff1 + "; " + coeff2 + Environment.NewLine);
                if (F_Over2 > 0.7 && F8_Over2 > 0.7)
                {
                    textBox28.AppendText("Over 2.5: " + 1 / F_Over2 + "; " + 1 / F8_Over2 + Environment.NewLine);
                }
            }
            if (Under2 > 0.7 && S_Under2 > 0.7)
            {
                coeff1 = 1 / Under2;
                coeff2 = 1 / S_Under2;
                textBox27.AppendText("Under 2.5: " + coeff1 + "; " + coeff2 + Environment.NewLine);
                if (F_Under2 > 0.7 && F8_Under2 > 0.7)
                {
                    textBox28.AppendText("Under 2.5: " + 1 / F_Under2 + "; " + 1 / F8_Under2 + Environment.NewLine);
                }
            }
            if (Over3 > 0.7 && S_Over3 > 0.7)
            {
                coeff1 = 1 / Over3;
                coeff2 = 1 / S_Over3;
                textBox27.AppendText("Over 3.5: " + coeff1 + "; " + coeff2 + Environment.NewLine);
                if (F_Over3 > 0.7 && F8_Over3 > 0.7)
                {
                    textBox28.AppendText("Over 3.5: " + 1 / F_Over3 + "; " + 1 / F8_Over3 + Environment.NewLine);
                }
            }
            if (Under3 > 0.7 && S_Under3 > 0.7)
            {
                coeff1 = 1 / Under3;
                coeff2 = 1 / S_Under3;
                textBox27.AppendText("Under 3.5: " + coeff1 + "; " + coeff2 + Environment.NewLine);
                if (F_Under3 > 0.7 && F8_Under3 > 0.7)
                {
                    textBox28.AppendText("Under 3.5: " + 1 / F_Under3 + "; " + 1 / F8_Under3 + Environment.NewLine);
                }
            }
            #endregion

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void list_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double max1 = 0, max2, maxB1 = 0;
            double val1, val2, val3, val4, valB1, valB2, valB3, valB4, Sval1, Sval2, Sval3, Sval4, SvalB1, SvalB2, SvalB3, SvalB4, Fval1, Fval2, Fval3, Fval4, FvalB1, FvalB2, FvalB3, FvalB4, F8val1, F8val2, F8val3, F8val4, F8valB1, F8valB2, F8valB3, F8valB4;
           
            List<double> range1 = new List<double>();
            List<double> range2 = new List<double>();

             for (int i = 121; i < listBox1.Items.Count; i++)
            {

                listBox1.SetSelected(i, true);
                String league = listBox1.GetItemText(listBox1.SelectedItem);

                string date = "", hour = "";
                button1_Click(this, new EventArgs());


                for (int j = 0; j < listBox2.Items.Count; j++)
                {
                    listBox2.SetSelected(j, true);
                    String game = listBox2.GetItemText(listBox2.SelectedItem);
                    button2_Click(this, new EventArgs());
                    if (listBox4.Items.Count > 0 && listBox3.Items.Count > 0 && listBox5.Items.Count > 0 && listBox6.Items.Count > 0 && listBox7.Items.Count > 0 && listBox8.Items.Count > 0 && listBox9.Items.Count > 0)
                    {
                        #region vars

                        double goalsHFor = Convert.ToDouble(listBox3.Items[0].ToString());
                        double goalsHAgainst = Convert.ToDouble(listBox3.Items[1].ToString());
                        double avgGoalsHFor = Convert.ToDouble(listBox5.Items[0].ToString());
                        double goalsAFor = Convert.ToDouble(listBox4.Items[0].ToString());
                        double goalsAAgainst = Convert.ToDouble(listBox4.Items[1].ToString());
                        double avgGoalsAFor = Convert.ToDouble(listBox5.Items[2].ToString());
                        double teamHomePower = goalsHFor * goalsAAgainst / avgGoalsHFor;
                        double teamAwayPower = goalsAFor * goalsHAgainst / avgGoalsAFor;

                        double goalsHForTotal = Convert.ToDouble(listBox3.Items[2].ToString());
                        double goalsHAgainstTotal = Convert.ToDouble(listBox3.Items[3].ToString());
                        double goalsAForTtal = Convert.ToDouble(listBox4.Items[2].ToString());
                        double goalsAAgainstTotal = Convert.ToDouble(listBox4.Items[3].ToString());
                        double teamHomePowerTotal = goalsHForTotal * goalsAAgainstTotal / avgGoalsHFor;
                        double teamAwayPowerTotal = goalsAForTtal * goalsHAgainstTotal / avgGoalsAFor;

                        double goalsHForForm = Convert.ToDouble(listBox8.Items[2].ToString());
                        goalsHForForm /= 4;
                        double goalsHAgainstForm = Convert.ToDouble(listBox7.Items[2].ToString());
                        goalsHAgainstForm /= 4;
                        double goalsAForForm = Convert.ToDouble(listBox6.Items[4].ToString());
                        goalsAForForm /= 4;
                        double goalsAAgainstForm = Convert.ToDouble(listBox9.Items[4].ToString());
                        goalsAAgainstForm /= 4;
                        double teamHomePowerForm = goalsHForForm * goalsAAgainstForm / avgGoalsHFor;
                        double teamAwayPowerForm = goalsAForForm * goalsHAgainstForm / avgGoalsAFor;

                        double goalsHForForm8 = Convert.ToDouble(listBox8.Items[3].ToString());
                        goalsHForForm8 /= 8;
                        double goalsHAgainstForm8 = Convert.ToDouble(listBox7.Items[3].ToString());
                        goalsHAgainstForm8 /= 8;
                        double goalsAForForm8 = Convert.ToDouble(listBox6.Items[5].ToString());
                        goalsAForForm8 /= 8;
                        double goalsAAgainstForm8 = Convert.ToDouble(listBox9.Items[5].ToString());
                        goalsAAgainstForm8 /= 8;
                        double teamHomePowerForm8 = goalsHForForm8 * goalsAAgainstForm8 / avgGoalsHFor;
                        double teamAwayPowerForm8 = goalsAForForm8 * goalsHAgainstForm8 / avgGoalsAFor;

                        #endregion

                        val1 = (Math.Pow(teamHomePower, 0)) / (Factorial(0) * Math.Pow(Math.E, teamHomePower));
                        val2 = (Math.Pow(teamHomePower, 1)) / (Factorial(1) * Math.Pow(Math.E, teamHomePower));
                        val3 = (Math.Pow(teamHomePower, 2)) / (Factorial(2) * Math.Pow(Math.E, teamHomePower));
                        val4 = (Math.Pow(teamHomePower, 3)) / (Factorial(3) * Math.Pow(Math.E, teamHomePower));
                        valB1 = (Math.Pow(teamAwayPower, 0)) / (Factorial(0) * Math.Pow(Math.E, teamAwayPower));
                        valB2 = (Math.Pow(teamAwayPower, 1)) / (Factorial(1) * Math.Pow(Math.E, teamAwayPower));
                        valB3 = (Math.Pow(teamAwayPower, 2)) / (Factorial(2) * Math.Pow(Math.E, teamAwayPower));
                        valB4 = (Math.Pow(teamAwayPower, 3)) / (Factorial(3) * Math.Pow(Math.E, teamAwayPower));

                        Sval1 = (Math.Pow(teamHomePowerTotal, 0)) / (Factorial(0) * Math.Pow(Math.E, teamHomePowerTotal));
                        Sval2 = (Math.Pow(teamHomePowerTotal, 1)) / (Factorial(1) * Math.Pow(Math.E, teamHomePowerTotal));
                        Sval3 = (Math.Pow(teamHomePowerTotal, 2)) / (Factorial(2) * Math.Pow(Math.E, teamHomePowerTotal));
                        Sval4 = (Math.Pow(teamHomePowerTotal, 3)) / (Factorial(3) * Math.Pow(Math.E, teamHomePowerTotal));
                        SvalB1 = (Math.Pow(teamAwayPowerTotal, 0)) / (Factorial(0) * Math.Pow(Math.E, teamAwayPowerTotal));
                        SvalB2 = (Math.Pow(teamAwayPowerTotal, 1)) / (Factorial(1) * Math.Pow(Math.E, teamAwayPowerTotal));
                        SvalB3 = (Math.Pow(teamAwayPowerTotal, 2)) / (Factorial(2) * Math.Pow(Math.E, teamAwayPowerTotal));
                        SvalB4 = (Math.Pow(teamAwayPowerTotal, 3)) / (Factorial(3) * Math.Pow(Math.E, teamAwayPowerTotal));

                        Fval1 = (Math.Pow(teamHomePowerForm, 0)) / (Factorial(0) * Math.Pow(Math.E, teamHomePowerForm));
                        Fval2 = (Math.Pow(teamHomePowerForm, 1)) / (Factorial(1) * Math.Pow(Math.E, teamHomePowerForm));
                        Fval3 = (Math.Pow(teamHomePowerForm, 2)) / (Factorial(2) * Math.Pow(Math.E, teamHomePowerForm));
                        Fval4 = (Math.Pow(teamHomePowerForm, 3)) / (Factorial(3) * Math.Pow(Math.E, teamHomePowerForm));
                        FvalB1 = (Math.Pow(teamAwayPowerForm, 0)) / (Factorial(0) * Math.Pow(Math.E, teamAwayPowerForm));
                        FvalB2 = (Math.Pow(teamAwayPowerForm, 1)) / (Factorial(1) * Math.Pow(Math.E, teamAwayPowerForm));
                        FvalB3 = (Math.Pow(teamAwayPowerForm, 2)) / (Factorial(2) * Math.Pow(Math.E, teamAwayPowerForm));
                        FvalB4 = (Math.Pow(teamAwayPowerForm, 3)) / (Factorial(3) * Math.Pow(Math.E, teamAwayPowerForm));

                        F8val1 = (Math.Pow(teamHomePowerForm8, 0)) / (Factorial(0) * Math.Pow(Math.E, teamHomePowerForm8));
                        F8val2 = (Math.Pow(teamHomePowerForm8, 1)) / (Factorial(1) * Math.Pow(Math.E, teamHomePowerForm8));
                        F8val3 = (Math.Pow(teamHomePowerForm8, 2)) / (Factorial(2) * Math.Pow(Math.E, teamHomePowerForm8));
                        F8val4 = (Math.Pow(teamHomePowerForm8, 3)) / (Factorial(3) * Math.Pow(Math.E, teamHomePowerForm8));
                        F8valB1 = (Math.Pow(teamAwayPowerForm8, 0)) / (Factorial(0) * Math.Pow(Math.E, teamAwayPowerForm8));
                        F8valB2 = (Math.Pow(teamAwayPowerForm8, 1)) / (Factorial(1) * Math.Pow(Math.E, teamAwayPowerForm8));
                        F8valB3 = (Math.Pow(teamAwayPowerForm8, 2)) / (Factorial(2) * Math.Pow(Math.E, teamAwayPowerForm8));
                        F8valB4 = (Math.Pow(teamAwayPowerForm8, 3)) / (Factorial(3) * Math.Pow(Math.E, teamAwayPowerForm8));


                        #region database
                        string month="August";
                        getDate(league, game, out date, out hour);
                        con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=dbo_Games;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        if (date == textBox54.Text)
                        {
                            String team1 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[0];
                            team1 = team1.Trim();
                            #region Over %
                            List<string> Over = new List<string>();                        
                            WebClient web = new WebClient();
                            do
                            {
                                try
                                {
                                    List<string> Links = new List<string>();
                                    webException = false;
                                    String html = web.DownloadString("http://www.soccerstats.com/latest.asp?league=" + league);
                               

                            if (listBox2.SelectedIndex != -1)
                            {
                                string short_team=team1.Substring(0,team1.Length-1);
                                MatchCollection m1 = Regex.Matches(html, team1 + @"\r\n&nbsp;.+?<a href='pm(.+?)' title='"+game, RegexOptions.Singleline);
                                foreach (Match m in m1)
                                {
                                    string link = m.Groups[1].Value;
                                    link = "pm" + link;
                                    //MessageBox.Show(link);
                                    Links.Add(link);
                                break;
                                }
                            }
                            else
                            {
                                MatchCollection m1 = Regex.Matches(html, @"<a href='pm(.+?)' title='" + game, RegexOptions.Singleline);
                                foreach (Match m in m1)
                                {
                                    string link = m.Groups[1].Value;
                                    link = "pm" + link;
                                    //MessageBox.Show(link);
                                    Links.Add(link);
                                    break;
                                }
                            }
                            if (Links.Count==0)
                            {
                                MatchCollection m1 = Regex.Matches(html, team1 + @" \r\n&nbsp;.+?<a href='pm(.+?)' title='" + game, RegexOptions.Singleline);
                                foreach (Match m in m1)
                                {
                                    string link = m.Groups[1].Value;
                                    link = "pm" + link;
                                    //MessageBox.Show(link);
                                    Links.Add(link);
                                    break;
                                }
                            }
                            //                            else
                            //                            {
                            //                                MatchCollection m1 = Regex.Matches(html, @">" + listBox2.Items[j - 1] + @".+?
                            //.+?
                            //.+?

                            //.+?
                            //<td colspan='3'><a href='(.+?)' title='" + game, RegexOptions.Singleline);
                            //                                foreach (Match m in m1)
                            //                                {
                            //                                    string link = m.Groups[1].Value;
                            //                                    Links.Add(link);
                            //                                }

                            //                            }

                           
                                html = web.DownloadString("http://www.soccerstats.com/" + Links[0]);
                                MatchCollection m3 = Regex.Matches(html, @"Matches over 1.5 goals
.+?
.+?&nbsp;<b>(.+?)%</b>.+?&nbsp;(.+?)%</td>.+?
Matches over", RegexOptions.Singleline);

                                MatchCollection m2 = Regex.Matches(html, @"Matches over 2.5 goals
</td><td width='13%' align='center'>(.+?)%&nbsp;.+?<b>(.+?)%</b>&nbsp;", RegexOptions.Singleline);

                                MatchCollection m4 = Regex.Matches(html, @"Matches over 4.5 goals
.+?
.+?<b>(.+?)%</b>.+?align='center'>(.+?)%</td>.+?
Both teams scored", RegexOptions.Singleline);

                                MatchCollection m5 = Regex.Matches(html, @"Both teams scored
</td><td width='13%' align='center'>(.+?)%</td>.+?<b>(.+?)%</b>.+?", RegexOptions.Singleline);

                                foreach (Match m in m2)
                                {
                                    string result = m.Groups[1].Value;
                                    Over.Add(result);
                                    //MessageBox.Show(result);
                                    result = m.Groups[2].Value;
                                    //result = result.Substring(result.Length - 2, 2);
                                    //MessageBox.Show(result);
                                    Over.Add(result);
                                }
                                foreach (Match m in m3)
                                {
                                    string result = m.Groups[1].Value;
                                    //MessageBox.Show(result);
                                    Over.Add(result);
                                    result = m.Groups[2].Value;
                                    //MessageBox.Show(result);
                                    Over.Add(result);
                                }

                                foreach (Match m in m4)
                                {
                                    string result = m.Groups[1].Value;
                                    //MessageBox.Show(result);
                                    Over.Add(result);
                                    result = m.Groups[2].Value;
                                    //MessageBox.Show(result);
                                    Over.Add(result);
                                }

                                foreach (Match m in m5)
                                {
                                    string result = m.Groups[1].Value;
                                    //MessageBox.Show(result);
                                    Over.Add(result);
                                    result = m.Groups[2].Value;
                                    //MessageBox.Show(result);
                                    Over.Add(result);
                                }
                                }
                                catch (WebException e4)
                                {
                                    webException = true;
                                }
                            } while (webException == true);
                            #endregion
                            con.Open();
                            //cmd = new SqlCommand("INSERT INTO Games (Date, Time, Game, Bet, Val1, Val2, Val3, Val4, ValB1, ValB2, ValB3, ValB4, Sval1, Sval2, Sval3, Sval4, SvalB1, SvalB2, SvalB3, SvalB4, Fval1, Fval2, Fval3, Fval4, FvalB1, FvalB2, FvalB3, FvalB4, F8val1, F8val2, F8val3, F8val4, F8valB1, F8valB2, F8valB3, F8valB4, Coeff_1, Coeff_X, Coeff_2, Coeff_GG, Coeff_NG, Coeff_O05, Coeff_O15, Coeff_O25, Coeff_U25, Coeff_U35, Coeff_U45, HOver25, TOver25, AOver25, ATOver25, HGG, TGG, AGG, ATGG) Values (@Date, @Time, @Game, @Bet, @Val1, @Val2, @Val3, @Val4, @ValB1, @ValB2, @ValB3, @ValB4, @Sval1, @Sval2, @Sval3, @Sval4, @SvalB1, @SvalB2, @SvalB3, @SvalB4, @Fval1, @Fval2, @Fval3, @Fval4, @FvalB1, @FvalB2, @FvalB3, @FvalB4, @F8val1, @F8val2, @F8val3, @F8val4, @F8valB1, @F8valB2, @F8valB3, @F8valB4, @Coeff_1, @Coeff_X, @Coeff_2, @Coeff_GG, @Coeff_NG, @Coeff_O05, @Coeff_O15, @Coeff_O25, @Coeff_U25, @Coeff_U35, @Coeff_U45, @HOver25, @TOver25, @AOver25, @ATOver25, @HGG, @TGG, @AGG, @ATGG)", con);
                            //cmd = new SqlCommand("INSERT INTO Games (Date, Time, Game, Bet, Val1, Val2, Val3, Val4, ValB1, ValB2, ValB3, ValB4, Sval1, Sval2, Sval3, Sval4, SvalB1, SvalB2, SvalB3, SvalB4, Fval1, Fval2, Fval3, Fval4, FvalB1, FvalB2, FvalB3, FvalB4, F8val1, F8val2, F8val3, F8val4, F8valB1, F8valB2, F8valB3, F8valB4, Coeff_O25, Coeff_U25, Coeff_U35, Coeff_U45) Values (@Date, @Time, @Game, @Bet, @Val1, @Val2, @Val3, @Val4, @ValB1, @ValB2, @ValB3, @ValB4, @Sval1, @Sval2, @Sval3, @Sval4, @SvalB1, @SvalB2, @SvalB3, @SvalB4, @Fval1, @Fval2, @Fval3, @Fval4, @FvalB1, @FvalB2, @FvalB3, @FvalB4, @F8val1, @F8val2, @F8val3, @F8val4, @F8valB1, @F8valB2, @F8valB3, @F8valB4, @Coeff_O25, @Coeff_U25, @Coeff_U35, @Coeff_U45)", con);
                            cmd = new SqlCommand("INSERT INTO Games (Date, Time, Game, Bet, Val1, Val2, Val3, Val4, ValB1, ValB2, ValB3, ValB4, Sval1, Sval2, Sval3, Sval4, SvalB1, SvalB2, SvalB3, SvalB4, Fval1, Fval2, Fval3, Fval4, FvalB1, FvalB2, FvalB3, FvalB4, F8val1, F8val2, F8val3, F8val4, F8valB1, F8valB2, F8valB3, F8valB4, HOver25, TOver25, AOver25, ATOver25, HGG, TGG, AGG, ATGG) Values (@Date, @Time, @Game, @Bet, @Val1, @Val2, @Val3, @Val4, @ValB1, @ValB2, @ValB3, @ValB4, @Sval1, @Sval2, @Sval3, @Sval4, @SvalB1, @SvalB2, @SvalB3, @SvalB4, @Fval1, @Fval2, @Fval3, @Fval4, @FvalB1, @FvalB2, @FvalB3, @FvalB4, @F8val1, @F8val2, @F8val3, @F8val4, @F8valB1, @F8valB2, @F8valB3, @F8valB4, @HOver25, @TOver25, @AOver25, @ATOver25, @HGG, @TGG, @AGG, @ATGG)", con);

                            cmd.Parameters.AddWithValue("@Date", date+" "+month);
                            cmd.Parameters.AddWithValue("@Time", hour);
                            cmd.Parameters.AddWithValue("@Game", game);
                            cmd.Parameters.AddWithValue("@Bet", "Under:");

                            cmd.Parameters.AddWithValue("@Val1", val1);
                            cmd.Parameters.AddWithValue("@Val2", val2);
                            cmd.Parameters.AddWithValue("@Val3", val3);
                            cmd.Parameters.AddWithValue("@Val4", val4);
                            cmd.Parameters.AddWithValue("@ValB1", valB1);
                            cmd.Parameters.AddWithValue("@ValB2", valB2);
                            cmd.Parameters.AddWithValue("@ValB3", valB3);
                            cmd.Parameters.AddWithValue("@ValB4", valB4);

                            cmd.Parameters.AddWithValue("@Sval1", Sval1);
                            cmd.Parameters.AddWithValue("@Sval2", Sval2);
                            cmd.Parameters.AddWithValue("@Sval3", Sval3);
                            cmd.Parameters.AddWithValue("@Sval4", Sval4);
                            cmd.Parameters.AddWithValue("@SvalB1", SvalB1);
                            cmd.Parameters.AddWithValue("@SvalB2", SvalB2);
                            cmd.Parameters.AddWithValue("@SvalB3", SvalB3);
                            cmd.Parameters.AddWithValue("@SvalB4", SvalB4);

                            cmd.Parameters.AddWithValue("@Fval1", Fval1);
                            cmd.Parameters.AddWithValue("@Fval2", Fval2);
                            cmd.Parameters.AddWithValue("@Fval3", Fval3);
                            cmd.Parameters.AddWithValue("@Fval4", Fval4);
                            cmd.Parameters.AddWithValue("@FValB1", FvalB1);
                            cmd.Parameters.AddWithValue("@FvalB2", FvalB2);
                            cmd.Parameters.AddWithValue("@FvalB3", FvalB3);
                            cmd.Parameters.AddWithValue("@FvalB4", FvalB4);

                            cmd.Parameters.AddWithValue("@F8val1", F8val1);
                            cmd.Parameters.AddWithValue("@F8val2", F8val2);
                            cmd.Parameters.AddWithValue("@F8val3", F8val3);
                            cmd.Parameters.AddWithValue("@F8val4", F8val4);
                            cmd.Parameters.AddWithValue("@F8valB1", F8valB1);
                            cmd.Parameters.AddWithValue("@F8valB2", F8valB2);
                            cmd.Parameters.AddWithValue("@F8valB3", F8valB3);
                            cmd.Parameters.AddWithValue("@F8valB4", F8valB4);
                            //cmd.Parameters.AddWithValue("@Coeff_1", getCoeff_1());
                            //cmd.Parameters.AddWithValue("@Coeff_X", getCoeff_X());
                            //cmd.Parameters.AddWithValue("@Coeff_2", getCoeff_2());
                            //cmd.Parameters.AddWithValue("@Coeff_GG", getCoeff_GG());
                            //cmd.Parameters.AddWithValue("@Coeff_NG", getCoeff_NG());
                            //cmd.Parameters.AddWithValue("@Coeff_O05", getCoeff_O05());
                            //cmd.Parameters.AddWithValue("@Coeff_O15", getCoeff_O15());
                            //cmd.Parameters.AddWithValue("@Coeff_O25", getCoeff_O25());
                            //cmd.Parameters.AddWithValue("@Coeff_U25", getCoeff_U25());
                            //cmd.Parameters.AddWithValue("@Coeff_U35", getCoeff_U35());
                            //cmd.Parameters.AddWithValue("@Coeff_U45", getCoeff_U45());
                             cmd.Parameters.AddWithValue("@HOver25", Over[2]);
                            cmd.Parameters.AddWithValue("@TOver25", Over[3]);
                            cmd.Parameters.AddWithValue("@AOver25", Over[1]);
                            cmd.Parameters.AddWithValue("@ATOver25", Over[0]);
                            cmd.Parameters.AddWithValue("@HGG", Over[4]);
                            cmd.Parameters.AddWithValue("@TGG", Over[5]);
                            cmd.Parameters.AddWithValue("@AGG", Over[7]);
                            cmd.Parameters.AddWithValue("@ATGG", Over[6]);
                            GC.Collect();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        #endregion
                       
                       
                    }
                    listBox2.SetSelected(j, false);
                }


                listBox1.SetSelected(i, false);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        public double getCoeff_1()
        {
            double final=0;
            bool boolGame = false, boolTeam = false;
            int elementNum = 0;
            for (int i = 0; i < leg.Count(); i++)
            {
                if(listBox1.GetItemText(listBox1.SelectedItem)==leg[i])
                {
                    boolGame = true;
                    break;
                }
            }
           
            String game = listBox2.GetItemText(listBox2.SelectedItem);
            
            List<string> links = new List<string>();
            string coeff = "";
            String team1 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[0];
            team1 = team1.Trim();
            if (boolGame == true)
            {
                for (int i = 0; i < teamConv.GetLength(0); i++)
                {
                    if (team1==teamConv[i,0])
                    {
                        team1 = teamConv[i, 1];
                        boolTeam = true;
                        break;
                    }
                }
            }
            if(boolTeam==false)
            {
                team1 = char.ToUpper(team1[0]) + team1.Substring(1);
            }
            
            
            String html = web.DownloadString("http://www.oddsportal.com/search/" + team1);
            MatchCollection link = Regex.Matches(html, @"script><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
            foreach (Match m in link)
            {
                string x = m.Groups[1].Value;
                links.Add(x);
            }

            if (listBox11.Items.Count < 70)
            {
                link = Regex.Matches(html, @"colspan=.2.><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
                foreach (Match m in link)
                {
                    string x = m.Groups[1].Value;
                    links.Add(x);
                }

                if (links.Count > 0)
                {
                  
                        textBox1.Text = "http://www.oddsportal.com/soccer" + links[0];
                   


                }
                else
                {
                    textBox1.Text="100";
                }

            }
            if (textBox1.Text != "100")
            {
                webBrowser1.ScriptErrorsSuppressed = true;
                object Zero = 0;
                object EmptyString = "";
                webBrowser1.Navigate(textBox1.Text);


                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {

                    Application.DoEvents();
                }

                for (int i = 0; i < listBox11.Items.Count; i++)
                {
                    string listItem = listBox11.Items[i].ToString();
                    if (listItem.Contains("target=bet365"))
                    {
                        elementNum = i;
                        break;
                    }


                }
                if (elementNum == 0)
                {
                    for (int i = 0; i < listBox11.Items.Count; i++)
                    {
                        string listItem = listBox11.Items[i].ToString();
                        if (listItem.Contains("target="))
                        {
                            elementNum = i;
                            break;
                        }
                    }
                }

                if (elementNum != 0)
                {
                    string search = listBox11.Items[elementNum].ToString();
                    int index = listBox11.FindString(search);
                    if (index != -1)
                    {
                        listBox11.SetSelected(index, true);
                        textBox2.Text = listBox11.SelectedItem.ToString();
                    }
                    coeff = textBox2.Text;
                    coeff = coeff.Remove(coeff.Length - 4);
                    if (coeff.Substring(coeff.Length - 5, 1) == ">")
                    {
                        coeff = coeff.Substring(coeff.Length - 4);
                    }
                    else
                    {
                        coeff = coeff.Substring(coeff.Length - 5);
                    }

                    listBox11.Items.Clear();
                    textBox2.Clear();
                    webBrowser1.Navigate("about:blank");
                    bool result = Double.TryParse(coeff, out final);
                    if (result)
                    {
                        return final;
                    }
                    else
                    {
                        return 0;
                    }
                    //return coeff;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
        public double getCoeff_X()
        {
            double final=0;
            bool boolGame = false, boolTeam = false;
            int elementNum = 0;
            for (int i = 0; i < leg.Count(); i++)
            {
                if (listBox1.GetItemText(listBox1.SelectedItem) == leg[i])
                {
                    boolGame = true;
                    break;
                }
            }

            String game = listBox2.GetItemText(listBox2.SelectedItem);

            List<string> links = new List<string>();
            string coeff = "";
            String team1 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[0];
            team1 = team1.Trim();
            if (boolGame == true)
            {
                for (int i = 0; i < teamConv.GetLength(0); i++)
                {
                    if (team1 == teamConv[i, 0])
                    {
                        team1 = teamConv[i, 1];
                        boolTeam = true;
                        break;
                    }
                }
            }
            if (boolTeam == false)
            {
                team1 = char.ToUpper(team1[0]) + team1.Substring(1);
            }


            String html = web.DownloadString("http://www.oddsportal.com/search/" + team1);
            MatchCollection link = Regex.Matches(html, @"script><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
            foreach (Match m in link)
            {
                string x = m.Groups[1].Value;
                links.Add(x);
            }

            if (listBox11.Items.Count < 70)
            {
                link = Regex.Matches(html, @"colspan=.2.><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
                foreach (Match m in link)
                {
                    string x = m.Groups[1].Value;
                    links.Add(x);
                }

                if (links.Count > 0)
                {

                    textBox1.Text = "http://www.oddsportal.com/soccer" + links[0];



                }
                else
                {
                    textBox1.Text = "100";
                }

            }
            if (textBox1.Text != "100")
            {
                webBrowser1.ScriptErrorsSuppressed = true;
                object Zero = 0;
                object EmptyString = "";
                webBrowser1.Navigate(textBox1.Text);


                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {

                    Application.DoEvents();
                }

                for (int i = 0; i < listBox11.Items.Count; i++)
                {
                    string listItem = listBox11.Items[i].ToString();
                    if (listItem.Contains("target=bet365"))
                    {
                        elementNum = i;
                        break;
                    }


                }
                if (elementNum == 0)
                {
                    for (int i = 0; i < listBox11.Items.Count; i++)
                    {
                        string listItem = listBox11.Items[i].ToString();
                        if (listItem.Contains("target="))
                        {
                            elementNum = i + 1;
                            break;
                        }
                    }
                }

                if (elementNum != 0)
                {
                    string search = listBox11.Items[elementNum + 1].ToString();
                    int index = listBox11.FindString(search);
                    if (index != -1)
                    {
                        listBox11.SetSelected(index, true);
                        textBox2.Text = listBox11.SelectedItem.ToString();
                    }
                    coeff = textBox2.Text;
                    coeff = coeff.Remove(coeff.Length - 4);
                    if (coeff.Substring(coeff.Length - 5, 1) == ">")
                    {
                        coeff = coeff.Substring(coeff.Length - 4);
                    }
                    else
                    {
                        coeff = coeff.Substring(coeff.Length - 5);
                    }

                    listBox11.Items.Clear();
                    textBox2.Clear();
                    webBrowser1.Navigate("about:blank");
                    bool result = Double.TryParse(coeff, out final);
                    if (result)
                    {
                        return final;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
        public double getCoeff_2()
        {
            double final=0;
            bool boolGame = false, boolTeam = false;
            int elementNum = 0;
            for (int i = 0; i < leg.Count(); i++)
            {
                if (listBox1.GetItemText(listBox1.SelectedItem) == leg[i])
                {
                    boolGame = true;
                    break;
                }
            }

            String game = listBox2.GetItemText(listBox2.SelectedItem);

            List<string> links = new List<string>();
            string coeff = "";
            String team1 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[0];
            team1 = team1.Trim();
            if (boolGame == true)
            {
                for (int i = 0; i < teamConv.GetLength(0); i++)
                {
                    if (team1 == teamConv[i, 0])
                    {
                        team1 = teamConv[i, 1];
                        boolTeam = true;
                        break;
                    }
                }
            }
            if (boolTeam == false)
            {
                team1 = char.ToUpper(team1[0]) + team1.Substring(1);
            }


            String html = web.DownloadString("http://www.oddsportal.com/search/" + team1);
            MatchCollection link = Regex.Matches(html, @"script><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
            foreach (Match m in link)
            {
                string x = m.Groups[1].Value;
                links.Add(x);
            }

            if (listBox11.Items.Count < 70)
            {
                link = Regex.Matches(html, @"colspan=.2.><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
                foreach (Match m in link)
                {
                    string x = m.Groups[1].Value;
                    links.Add(x);
                }

                if (links.Count > 0)
                {

                    textBox1.Text = "http://www.oddsportal.com/soccer" + links[0];



                }
                else
                {
                    textBox1.Text = "100";
                }

            }
            if (textBox1.Text != "100")
            {
                webBrowser1.ScriptErrorsSuppressed = true;
                object Zero = 0;
                object EmptyString = "";
                webBrowser1.Navigate(textBox1.Text);


                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {

                    Application.DoEvents();
                }

                for (int i = 0; i < listBox11.Items.Count; i++)
                {
                    string listItem = listBox11.Items[i].ToString();
                    if (listItem.Contains("target=bet365"))
                    {
                        elementNum = i;
                        break;
                    }


                }
                if (elementNum == 0)
                {
                    for (int i = 0; i < listBox11.Items.Count; i++)
                    {
                        string listItem = listBox11.Items[i].ToString();
                        if (listItem.Contains("target="))
                        {
                            elementNum = i + 2;
                            break;
                        }
                    }
                }

                if (elementNum != 0)
                {
                    string search = listBox11.Items[elementNum + 2].ToString();
                    int index = listBox11.FindString(search);
                    if (index != -1)
                    {
                        listBox11.SetSelected(index, true);
                        textBox2.Text = listBox11.SelectedItem.ToString();
                    }
                    coeff = textBox2.Text;
                    coeff = coeff.Remove(coeff.Length - 4);
                    if (coeff.Substring(coeff.Length - 5, 1) == ">")
                    {
                        coeff = coeff.Substring(coeff.Length - 4);
                    }
                    else
                    {
                        coeff = coeff.Substring(coeff.Length - 5);
                    }

                    listBox11.Items.Clear();
                    textBox2.Clear();
                    webBrowser1.Navigate("about:blank");
                    bool result = Double.TryParse(coeff, out final);
                    if (result)
                    {
                        return final;
                    }
                    else
                    {
                        return 0;
                    }
                    //return coeff;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
        public double getCoeff_GG()
        {
            double final=0;
            bool boolGame = false, boolTeam = false;
            int elementNum = 0;
            for (int i = 0; i < leg.Count(); i++)
            {
                if (listBox1.GetItemText(listBox1.SelectedItem) == leg[i])
                {
                    boolGame = true;
                    break;
                }
            }

            String game = listBox2.GetItemText(listBox2.SelectedItem);

            List<string> links = new List<string>();
            string coeff = "";
            String team1 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[0];
            team1 = team1.Trim();
            if (boolGame == true)
            {
                for (int i = 0; i < teamConv.GetLength(0); i++)
                {
                    if (team1 == teamConv[i, 0])
                    {
                        team1 = teamConv[i, 1];
                        boolTeam = true;
                        break;
                    }
                }
            }
            if (boolTeam == false)
            {
                team1 = char.ToUpper(team1[0]) + team1.Substring(1);
            }


            String html = web.DownloadString("http://www.oddsportal.com/search/" + team1);
            MatchCollection link = Regex.Matches(html, @"script><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
            foreach (Match m in link)
            {
                string x = m.Groups[1].Value;
                links.Add(x);
            }

            if (listBox11.Items.Count < 70)
            {
                link = Regex.Matches(html, @"colspan=.2.><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
                foreach (Match m in link)
                {
                    string x = m.Groups[1].Value;
                    links.Add(x);
                }

                if (links.Count > 0)
                {

                    textBox1.Text = "http://www.oddsportal.com/soccer" + links[0] + "/#bts;2";



                }
                else
                {
                    textBox1.Text = "100";
                }

            }
            if (textBox1.Text != "100")
            {
                webBrowser1.ScriptErrorsSuppressed = true;
                object Zero = 0;
                object EmptyString = "";
                webBrowser1.Navigate(textBox1.Text);


                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {

                    Application.DoEvents();
                }

                for (int i = 0; i < listBox11.Items.Count; i++)
                {
                    string listItem = listBox11.Items[i].ToString();
                    if (listItem.Contains("target=bet365"))
                    {
                        elementNum = i;
                        break;
                    }


                }
                if (elementNum == 0)
                {
                    for (int i = 0; i < listBox11.Items.Count; i++)
                    {
                        string listItem = listBox11.Items[i].ToString();
                        if (listItem.Contains("target="))
                        {
                            elementNum = i;
                            break;
                        }
                    }
                }

                if (elementNum != 0)
                {
                    string search = listBox11.Items[elementNum].ToString();
                    int index = listBox11.FindString(search);
                    if (index != -1)
                    {
                        listBox11.SetSelected(index, true);
                        textBox2.Text = listBox11.SelectedItem.ToString();
                    }
                    coeff = textBox2.Text;
                    coeff = coeff.Remove(coeff.Length - 4);
                    if (coeff.Substring(coeff.Length - 5, 1) == ">")
                    {
                        coeff = coeff.Substring(coeff.Length - 4);
                    }
                    else
                    {
                        coeff = coeff.Substring(coeff.Length - 5);
                    }

                    listBox11.Items.Clear();
                    textBox2.Clear();
                    webBrowser1.Navigate("about:blank");
                    bool result = Double.TryParse(coeff, out final);
                    if (result)
                    {
                        return final;
                    }
                    else
                    {
                        return 0;
                    }
                    //return coeff;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
        public double getCoeff_NG()
        {
            double final=0;
            bool boolGame = false, boolTeam = false;
            int elementNum = 0;
            for (int i = 0; i < leg.Count(); i++)
            {
                if (listBox1.GetItemText(listBox1.SelectedItem) == leg[i])
                {
                    boolGame = true;
                    break;
                }
            }

            String game = listBox2.GetItemText(listBox2.SelectedItem);

            List<string> links = new List<string>();
            string coeff = "";
            String team1 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[0];
            team1 = team1.Trim();
            if (boolGame == true)
            {
                for (int i = 0; i < teamConv.GetLength(0); i++)
                {
                    if (team1 == teamConv[i, 0])
                    {
                        team1 = teamConv[i, 1];
                        boolTeam = true;
                        break;
                    }
                }
            }
            if (boolTeam == false)
            {
                team1 = char.ToUpper(team1[0]) + team1.Substring(1);
            }


            String html = web.DownloadString("http://www.oddsportal.com/search/" + team1);
            MatchCollection link = Regex.Matches(html, @"script><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
            foreach (Match m in link)
            {
                string x = m.Groups[1].Value;
                links.Add(x);
            }

            if (listBox11.Items.Count < 70)
            {
                link = Regex.Matches(html, @"colspan=.2.><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
                foreach (Match m in link)
                {
                    string x = m.Groups[1].Value;
                    links.Add(x);
                }

                if (links.Count > 0)
                {

                    textBox1.Text = "http://www.oddsportal.com/soccer" + links[0] + "#bts;2";



                }
                else
                {
                    textBox1.Text = "100";
                }

            }
            if (textBox1.Text != "100")
            {
                webBrowser1.ScriptErrorsSuppressed = true;
                object Zero = 0;
                object EmptyString = "";
                webBrowser1.Navigate(textBox1.Text);


                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {

                    Application.DoEvents();
                }

                for (int i = 0; i < listBox11.Items.Count; i++)
                {
                    string listItem = listBox11.Items[i].ToString();
                    if (listItem.Contains("target=bet365"))
                    {
                        elementNum = i;
                        break;
                    }


                }
                if (elementNum == 0)
                {
                    for (int i = 0; i < listBox11.Items.Count; i++)
                    {
                        string listItem = listBox11.Items[i].ToString();
                        if (listItem.Contains("target="))
                        {
                            elementNum = i;
                            break;
                        }
                    }
                }

                if (elementNum != 0)
                {
                    string search = listBox11.Items[elementNum + 1].ToString();
                    int index = listBox11.FindString(search);
                    if (index != -1)
                    {
                        listBox11.SetSelected(index, true);
                        textBox2.Text = listBox11.SelectedItem.ToString();
                    }
                    coeff = textBox2.Text;
                    coeff = coeff.Remove(coeff.Length - 4);
                    if (coeff.Substring(coeff.Length - 5, 1) == ">")
                    {
                        coeff = coeff.Substring(coeff.Length - 4);
                    }
                    else
                    {
                        coeff = coeff.Substring(coeff.Length - 5);
                    }

                    listBox11.Items.Clear();
                    textBox2.Clear();
                    webBrowser1.Navigate("about:blank");
                    bool result = Double.TryParse(coeff, out final);
                    if (result)
                    {
                        return final;
                    }
                    else
                    {
                        return 0;
                    }
                    //return coeff;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
        public double getCoeff_O05()
        {
            double final=0;
            bool boolGame = false, boolTeam = false;
            int elementNum = 0;
            for (int i = 0; i < leg.Count(); i++)
            {
                if (listBox1.GetItemText(listBox1.SelectedItem) == leg[i])
                {
                    boolGame = true;
                    break;
                }
            }

            String game = listBox2.GetItemText(listBox2.SelectedItem);

            List<string> links = new List<string>();
            string coeff = "";
            String team1 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[0];
            team1 = team1.Trim();
            if (boolGame == true)
            {
                for (int i = 0; i < teamConv.GetLength(0); i++)
                {
                    if (team1 == teamConv[i, 0])
                    {
                        team1 = teamConv[i, 1];
                        boolTeam = true;
                        break;
                    }
                }
            }
            if (boolTeam == false)
            {
                team1 = char.ToUpper(team1[0]) + team1.Substring(1);
            }


            String html = web.DownloadString("http://www.oddsportal.com/search/" + team1);
            MatchCollection link = Regex.Matches(html, @"script><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
            foreach (Match m in link)
            {
                string x = m.Groups[1].Value;
                links.Add(x);
            }

            if (listBox11.Items.Count < 70)
            {
                link = Regex.Matches(html, @"colspan=.2.><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
                foreach (Match m in link)
                {
                    string x = m.Groups[1].Value;
                    links.Add(x);
                }

                if (links.Count > 0)
                {

                    textBox1.Text = "http://www.oddsportal.com/soccer" + links[0] + "/#over-under;2;0.50;0";



                }
                else
                {
                    textBox1.Text = "100";
                }

            }
            if (textBox1.Text != "100")
            {
                webBrowser1.ScriptErrorsSuppressed = true;
                object Zero = 0;
                object EmptyString = "";
                webBrowser1.Navigate(textBox1.Text);


                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {

                    Application.DoEvents();
                }

                for (int i = 0; i < listBox11.Items.Count; i++)
                {
                    string listItem = listBox11.Items[i].ToString();
                    if (listItem.Contains("target=bet365"))
                    {
                        elementNum = i;
                        break;
                    }


                }
                if (elementNum == 0)
                {
                    for (int i = 0; i < listBox11.Items.Count; i++)
                    {
                        string listItem = listBox11.Items[i].ToString();
                        if (listItem.Contains("Over/Under +0.5"))
                        {
                            elementNum = i + 2;
                            break;
                        }
                    }
                }

                if (elementNum != 0)
                {
                    string search = listBox11.Items[elementNum].ToString();
                    int index = listBox11.FindString(search);
                    if (index != -1)
                    {
                        listBox11.SetSelected(index, true);
                        textBox2.Text = listBox11.SelectedItem.ToString();
                    }
                    coeff = textBox2.Text;
                    coeff = coeff.Remove(coeff.Length - 4);
                    if (coeff.Substring(coeff.Length - 5, 1) == ">")
                    {
                        coeff = coeff.Substring(coeff.Length - 4);
                    }
                    else
                    {
                        coeff = coeff.Substring(coeff.Length - 5);
                    }

                    listBox11.Items.Clear();
                    textBox2.Clear();
                    webBrowser1.Navigate("about:blank");
                    bool result = Double.TryParse(coeff, out final);
                    if (result)
                    {
                        return final;
                    }
                    else
                    {
                        return 0;
                    }
                    //return coeff;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
        public double getCoeff_O15()
        {
            double final=0;
            bool boolGame = false, boolTeam = false;
            int elementNum = 0;
            for (int i = 0; i < leg.Count(); i++)
            {
                if (listBox1.GetItemText(listBox1.SelectedItem) == leg[i])
                {
                    boolGame = true;
                    break;
                }
            }

            String game = listBox2.GetItemText(listBox2.SelectedItem);

            List<string> links = new List<string>();
            string coeff = "";
            String team1 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[0];
            team1 = team1.Trim();
            if (boolGame == true)
            {
                for (int i = 0; i < teamConv.GetLength(0); i++)
                {
                    if (team1 == teamConv[i, 0])
                    {
                        team1 = teamConv[i, 1];
                        boolTeam = true;
                        break;
                    }
                }
            }
            if (boolTeam == false)
            {
                team1 = char.ToUpper(team1[0]) + team1.Substring(1);
            }


            String html = web.DownloadString("http://www.oddsportal.com/search/" + team1);
            MatchCollection link = Regex.Matches(html, @"script><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
            foreach (Match m in link)
            {
                string x = m.Groups[1].Value;
                links.Add(x);
            }

            if (listBox11.Items.Count < 70)
            {
                link = Regex.Matches(html, @"colspan=.2.><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
                foreach (Match m in link)
                {
                    string x = m.Groups[1].Value;
                    links.Add(x);
                }

                if (links.Count > 0)
                {

                    textBox1.Text = "http://www.oddsportal.com/soccer" + links[0] + "#over-under;2;1.50;0";



                }
                else
                {
                    textBox1.Text = "100";
                }

            }
            if (textBox1.Text != "100")
            {
                webBrowser1.ScriptErrorsSuppressed = true;
                object Zero = 0;
                object EmptyString = "";
                webBrowser1.Navigate(textBox1.Text);


                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {

                    Application.DoEvents();
                }

                for (int i = 0; i < listBox11.Items.Count; i++)
                {
                    string listItem = listBox11.Items[i].ToString();
                    if (listItem.Contains("target=bet365"))
                    {
                        elementNum = i;
                        break;
                    }


                }
                if (elementNum == 0)
                {
                    for (int i = 0; i < listBox11.Items.Count; i++)
                    {
                        string listItem = listBox11.Items[i].ToString();
                        if (listItem.Contains("Over/Under +1.5"))
                        {
                            elementNum = i + 2;
                            break;
                        }
                    }
                }

                if (elementNum != 0)
                {
                    string search = listBox11.Items[elementNum].ToString();
                    int index = listBox11.FindString(search);
                    if (index != -1)
                    {
                        listBox11.SetSelected(index, true);
                        textBox2.Text = listBox11.SelectedItem.ToString();
                    }
                    coeff = textBox2.Text;
                    coeff = coeff.Remove(coeff.Length - 4);
                    if (coeff.Substring(coeff.Length - 5, 1) == ">")
                    {
                        coeff = coeff.Substring(coeff.Length - 4);
                    }
                    else
                    {
                        coeff = coeff.Substring(coeff.Length - 5);
                    }

                    listBox11.Items.Clear();
                    textBox2.Clear();
                    webBrowser1.Navigate("about:blank");
                    bool result = Double.TryParse(coeff, out final);
                    if (result)
                    {
                        return final;
                    }
                    else
                    {
                        return 0;
                    }
                    //return coeff;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
        public double getCoeff_O25()
        {
            double final = 0;
            bool boolGame = false, boolTeam = false;
            int elementNum = 0;
            for (int i = 0; i < leg.Count(); i++)
            {
                if (listBox1.GetItemText(listBox1.SelectedItem) == leg[i])
                {
                    boolGame = true;
                    break;
                }
            }

            String game = listBox2.GetItemText(listBox2.SelectedItem);

            List<string> links = new List<string>();
            string coeff = "";
            String team1 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[0];
            team1 = team1.Trim();
            if (boolGame == true)
            {
                for (int i = 0; i < teamConv.GetLength(0); i++)
                {
                    if (team1 == teamConv[i, 0])
                    {
                        team1 = teamConv[i, 1];
                        boolTeam = true;
                        break;
                    }
                }
            }
            if (boolTeam == false)
            {
                team1 = char.ToUpper(team1[0]) + team1.Substring(1);
            }


            String html = web.DownloadString("http://www.oddsportal.com/search/" + team1);
            MatchCollection link = Regex.Matches(html, @"script><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
            foreach (Match m in link)
            {
                string x = m.Groups[1].Value;
                links.Add(x);
            }

            if (listBox11.Items.Count < 70)
            {
                link = Regex.Matches(html, @"colspan=.2.><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
                foreach (Match m in link)
                {
                    string x = m.Groups[1].Value;
                    links.Add(x);
                }

                if (links.Count > 0)
                {

                    textBox1.Text = "http://www.oddsportal.com/soccer" + links[0] + "#over-under;2;2.50;0";



                }
                else
                {
                    textBox1.Text = "100";
                }

            }
            if (textBox1.Text != "100")
            {
                webBrowser2.ScriptErrorsSuppressed = true;
                object Zero = 0;
                object EmptyString = "";
                webBrowser2.Navigate(textBox1.Text);


                while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
                {

                    Application.DoEvents();
                }

                for (int i = 0; i < listBox11.Items.Count; i++)
                {
                    string listItem = listBox11.Items[i].ToString();
                    if (listItem.Contains("target=bet365"))
                    {
                        elementNum = i;
                        break;
                    }


                }
                if (elementNum == 0)
                {
                    for (int i = 0; i < listBox11.Items.Count; i++)
                    {
                        string listItem = listBox11.Items[i].ToString();
                        if (listItem.Contains("Over/Under +2.5"))
                        {
                            elementNum = i + 1;
                            break;
                        }
                    }
                }

                if (elementNum != 0)
                {
                    string search = listBox11.Items[elementNum + 1].ToString();
                    int index = listBox11.FindString(search);
                    if (index != -1)
                    {
                        listBox11.SetSelected(index, true);
                        textBox2.Text = listBox11.SelectedItem.ToString();
                    }
                    coeff = textBox2.Text;
                    coeff = coeff.Remove(coeff.Length - 4);
                    if (coeff.Substring(coeff.Length - 5, 1) == ">")
                    {
                        coeff = coeff.Substring(coeff.Length - 4);
                    }
                    else
                    {
                        coeff = coeff.Substring(coeff.Length - 5);
                    }

                    listBox11.Items.Clear();
                    textBox2.Clear();
                    webBrowser2.Navigate("about:blank");
                    bool result = Double.TryParse(coeff, out final);
                    if (result)
                    {
                        return final;
                    }
                    else
                    {
                        return 0;
                    }
                    //return coeff;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
        public double getCoeff_U25()
        {
            double final=0;
            bool boolGame = false, boolTeam = false;
            int elementNum = 0;
            for (int i = 0; i < leg.Count(); i++)
            {
                if (listBox1.GetItemText(listBox1.SelectedItem) == leg[i])
                {
                    boolGame = true;
                    break;
                }
            }

            String game = listBox2.GetItemText(listBox2.SelectedItem);

            List<string> links = new List<string>();
            string coeff = "";
            String team1 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[0];
            team1 = team1.Trim();
            if (boolGame == true)
            {
                for (int i = 0; i < teamConv.GetLength(0); i++)
                {
                    if (team1 == teamConv[i, 0])
                    {
                        team1 = teamConv[i, 1];
                        boolTeam = true;
                        break;
                    }
                }
            }
            if (boolTeam == false)
            {
                team1 = char.ToUpper(team1[0]) + team1.Substring(1);
            }


            String html = web.DownloadString("http://www.oddsportal.com/search/" + team1);
            MatchCollection link = Regex.Matches(html, @"script><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
            foreach (Match m in link)
            {
                string x = m.Groups[1].Value;
                links.Add(x);
            }

            if (listBox11.Items.Count < 70)
            {
                link = Regex.Matches(html, @"colspan=.2.><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
                foreach (Match m in link)
                {
                    string x = m.Groups[1].Value;
                    links.Add(x);
                }

                if (links.Count > 0)
                {

                    textBox1.Text = "http://www.oddsportal.com/soccer" + links[0] + "#over-under;2;2.50;0";



                }
                else
                {
                    textBox1.Text = "100";
                }

            }
            if (textBox1.Text != "100")
            {
                webBrowser2.ScriptErrorsSuppressed = true;
                object Zero = 0;
                object EmptyString = "";
                webBrowser2.Navigate(textBox1.Text);


                while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
                {

                    Application.DoEvents();
                }

                for (int i = 0; i < listBox11.Items.Count; i++)
                {
                    string listItem = listBox11.Items[i].ToString();
                    if (listItem.Contains("target=bet365"))
                    {
                        elementNum = i;
                        break;
                    }


                }
                if (elementNum == 0)
                {
                    for (int i = 0; i < listBox11.Items.Count; i++)
                    {
                        string listItem = listBox11.Items[i].ToString();
                        if (listItem.Contains("Over/Under +2.5"))
                        {
                            elementNum = i;
                            break;
                        }
                    }
                }

                if (elementNum != 0)
                {
                    string search = listBox11.Items[elementNum + 1].ToString();
                    int index = listBox11.FindString(search);
                    if (index != -1)
                    {
                        listBox11.SetSelected(index, true);
                        textBox2.Text = listBox11.SelectedItem.ToString();
                    }
                    coeff = textBox2.Text;
                    coeff = coeff.Remove(coeff.Length - 4);
                    if (coeff.Substring(coeff.Length - 5, 1) == ">")
                    {
                        coeff = coeff.Substring(coeff.Length - 4);
                    }
                    else
                    {
                        coeff = coeff.Substring(coeff.Length - 5);
                    }

                    listBox11.Items.Clear();
                    textBox2.Clear();
                    webBrowser2.Navigate("about:blank");
                    bool result = Double.TryParse(coeff, out final);
                    if (result)
                    {
                        return final;
                    }
                    else
                    {
                        return 0;
                    }
                    //return coeff;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
        public double getCoeff_U35()
        {
            double final=0;
            bool boolGame = false, boolTeam = false;
            int elementNum = 0;
            for (int i = 0; i < leg.Count(); i++)
            {
                if (listBox1.GetItemText(listBox1.SelectedItem) == leg[i])
                {
                    boolGame = true;
                    break;
                }
            }

            String game = listBox2.GetItemText(listBox2.SelectedItem);

            List<string> links = new List<string>();
            string coeff = "";
            String team1 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[0];
            team1 = team1.Trim();
            if (boolGame == true)
            {
                for (int i = 0; i < teamConv.GetLength(0); i++)
                {
                    if (team1 == teamConv[i, 0])
                    {
                        team1 = teamConv[i, 1];
                        boolTeam = true;
                        break;
                    }
                }
            }
            if (boolTeam == false)
            {
                team1 = char.ToUpper(team1[0]) + team1.Substring(1);
            }


            String html = web.DownloadString("http://www.oddsportal.com/search/" + team1);
            MatchCollection link = Regex.Matches(html, @"script><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
            foreach (Match m in link)
            {
                string x = m.Groups[1].Value;
                links.Add(x);
            }

            if (listBox11.Items.Count < 70)
            {
                link = Regex.Matches(html, @"colspan=.2.><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
                foreach (Match m in link)
                {
                    string x = m.Groups[1].Value;
                    links.Add(x);
                }

                if (links.Count > 0)
                {

                    textBox1.Text = "http://www.oddsportal.com/soccer" + links[0] + "#over-under;2;3.50;0";



                }
                else
                {
                    textBox1.Text = "100";
                }

            }
            if (textBox1.Text != "100")
            {
                webBrowser2.ScriptErrorsSuppressed = true;
                object Zero = 0;
                object EmptyString = "";
                webBrowser2.Navigate(textBox1.Text);


                while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
                {

                    Application.DoEvents();
                }

                for (int i = 0; i < listBox11.Items.Count; i++)
                {
                    string listItem = listBox11.Items[i].ToString();
                    if (listItem.Contains("target=bet365"))
                    {
                        elementNum = i;
                        break;
                    }


                }
                if (elementNum == 0)
                {
                    for (int i = 0; i < listBox11.Items.Count; i++)
                    {
                        string listItem = listBox11.Items[i].ToString();
                        if (listItem.Contains("Over/Under +3.5"))
                        {
                            elementNum = i;
                            break;
                        }
                    }
                }

                if (elementNum != 0)
                {
                    string search = listBox11.Items[elementNum + 1].ToString();
                    int index = listBox11.FindString(search);
                    if (index != -1)
                    {
                        listBox11.SetSelected(index, true);
                        textBox2.Text = listBox11.SelectedItem.ToString();
                    }
                    coeff = textBox2.Text;
                    coeff = coeff.Remove(coeff.Length - 4);
                    if (coeff.Substring(coeff.Length - 5, 1) == ">")
                    {
                        coeff = coeff.Substring(coeff.Length - 4);
                    }
                    else
                    {
                        coeff = coeff.Substring(coeff.Length - 5);
                    }

                    listBox11.Items.Clear();
                    textBox2.Clear();
                    webBrowser2.Navigate("about:blank");
                    bool result = Double.TryParse(coeff, out final);
                    if (result)
                    {
                        return final;
                    }
                    else
                    {
                        return 0;
                    }
                    //return coeff;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
        public double getCoeff_U45()
        {
            double final=0;
            bool boolGame = false, boolTeam = false;
            int elementNum = 0;
            for (int i = 0; i < leg.Count(); i++)
            {
                if (listBox1.GetItemText(listBox1.SelectedItem) == leg[i])
                {
                    boolGame = true;
                    break;
                }
            }

            String game = listBox2.GetItemText(listBox2.SelectedItem);

            List<string> links = new List<string>();
            string coeff = "";
            String team1 = game.Split(new string[] { "vs" }, StringSplitOptions.None)[0];
            team1 = team1.Trim();
            if (boolGame == true)
            {
                for (int i = 0; i < teamConv.GetLength(0); i++)
                {
                    if (team1 == teamConv[i, 0])
                    {
                        team1 = teamConv[i, 1];
                        boolTeam = true;
                        break;
                    }
                }
            }
            if (boolTeam == false)
            {
                team1 = char.ToUpper(team1[0]) + team1.Substring(1);
            }


            String html = web.DownloadString("http://www.oddsportal.com/search/" + team1);
            MatchCollection link = Regex.Matches(html, @"script><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
            foreach (Match m in link)
            {
                string x = m.Groups[1].Value;
                links.Add(x);
            }

            if (listBox11.Items.Count < 70)
            {
                link = Regex.Matches(html, @"colspan=.2.><a href=./soccer(.+?).>" + team1, RegexOptions.Singleline);
                foreach (Match m in link)
                {
                    string x = m.Groups[1].Value;
                    links.Add(x);
                }

                if (links.Count > 0)
                {

                    textBox1.Text = "http://www.oddsportal.com/soccer" + links[0] + "#over-under;2;4.50;0";



                }
                else
                {
                    textBox1.Text = "100";
                }

            }
            if (textBox1.Text != "100")
            {
                webBrowser2.ScriptErrorsSuppressed = true;
                object Zero = 0;
                object EmptyString = "";
                webBrowser2.Navigate(textBox1.Text);


                while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
                {

                    Application.DoEvents();
                }

                for (int i = 0; i < listBox11.Items.Count; i++)
                {
                    string listItem = listBox11.Items[i].ToString();
                    if (listItem.Contains("target=bet365"))
                    {
                        elementNum = i;
                        break;
                    }


                }
                if (elementNum == 0)
                {
                    for (int i = 0; i < listBox11.Items.Count; i++)
                    {
                        string listItem = listBox11.Items[i].ToString();
                        if (listItem.Contains("Over/Under +4.5"))
                        {
                            elementNum = i;
                            break;
                        }
                    }
                }

                if (elementNum != 0)
                {
                    string search = listBox11.Items[elementNum + 1].ToString();
                    int index = listBox11.FindString(search);
                    if (index != -1)
                    {
                        listBox11.SetSelected(index, true);
                        textBox2.Text = listBox11.SelectedItem.ToString();
                    }
                    coeff = textBox2.Text;
                    coeff = coeff.Remove(coeff.Length - 4);
                    if (coeff.Substring(coeff.Length - 5, 1) == ">")
                    {
                        coeff = coeff.Substring(coeff.Length - 4);
                    }
                    else
                    {
                        coeff = coeff.Substring(coeff.Length - 5);
                    }

                    listBox11.Items.Clear();
                    textBox2.Clear();
                    webBrowser2.Navigate("about:blank");
                    bool result = Double.TryParse(coeff, out final);
                    if (result)
                    {
                        return final;
                    }
                    else
                    {
                        return 0;
                    }
                    //return coeff;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            GC.Collect();
            SHDocVw.WebBrowser wb;
            wb = (SHDocVw.WebBrowser)webBrowser1.ActiveXInstance;
            IHTMLDocument2 HTMLDocument = (IHTMLDocument2)wb.Document;
            IHTMLElementCollection links = HTMLDocument.links;

            listBox11.Items.Clear();

            foreach (HTMLAnchorElement el in links)
            {
                listBox11.Items.Add(el.outerHTML);
            }
            
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            GC.Collect();
            SHDocVw.WebBrowser wb;
            wb = (SHDocVw.WebBrowser)webBrowser2.ActiveXInstance;
            IHTMLDocument2 HTMLDocument = (IHTMLDocument2)wb.Document;
            IHTMLElementCollection links = HTMLDocument.links;

            listBox11.Items.Clear();

            foreach (HTMLAnchorElement el in links)
            {
                listBox11.Items.Add(el.outerHTML);
            }
        }
    }
}