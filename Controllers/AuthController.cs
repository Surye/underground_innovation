using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UndergroundInnovation.Models;
using UndergroundInnovation.Models.AccountViewModels;

namespace UndergroundInnovation.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("~/api/auth/login")]
        [Produces("application/json")]
        public async Task<object> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Username);
                return await GenerateJwtToken(model.Username, appUser);
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }

        [AllowAnonymous]
        [HttpPost("~/api/auth/register")]
        public async Task<object> Register(RegisterViewModel model)
        {
            // TODO: Validate
            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return await GenerateJwtToken(model.Email, user);
            }

            throw new ApplicationException("UNKNOWN_ERROR");
        }

        [AllowAnonymous]
        [HttpGet("~/seed")]
        public async void Seed()
        {
            ApplicationUser[] newUsers = {
                new ApplicationUser { Email = "joe.taylor@fictitious.mil", FullName = "Joe Taylor", UserName = "joe.taylor@fictitious.mil"},
                new ApplicationUser { Email = "gabrielle.manning@fictitious.mil", FullName = "Gabrielle Manning", UserName = "gabrielle.manning@fictitious.mil"},
                new ApplicationUser { Email = "connor.thomson@fictitious.mil", FullName = "Connor Thomson", UserName = "connor.thomson@fictitious.mil"},
                new ApplicationUser { Email = "rose.rutherford@fictitious.mil", FullName = "Rose Rutherford", UserName = "rose.rutherford@fictitious.mil"},
                new ApplicationUser { Email = "lily.morrison@fictitious.mil", FullName = "Lily Morrison", UserName = "lily.morrison@fictitious.mil"},
                new ApplicationUser { Email = "william.mcdonald@fictitious.mil", FullName = "William McDonald", UserName = "william.mcdonald@fictitious.mil"},
                new ApplicationUser { Email = "steven.bower@fictitious.mil", FullName = "Steven Bower", UserName = "steven.bower@fictitious.mil"},
                new ApplicationUser { Email = "lillian.smith@fictitious.mil", FullName = "Lillian Smith", UserName = "lillian.smith@fictitious.mil"},
                new ApplicationUser { Email = "brian.gibson@fictitious.mil", FullName = "Brian Gibson", UserName = "brian.gibson@fictitious.mil"},
                new ApplicationUser { Email = "ella.coleman@fictitious.mil", FullName = "Ella Coleman", UserName = "ella.coleman@fictitious.mil"},
                new ApplicationUser { Email = "warren.rutherford@fictitious.mil", FullName = "Warren Rutherford", UserName = "warren.rutherford@fictitious.mil"},
                new ApplicationUser { Email = "amelia.hemmings@fictitious.mil", FullName = "Amelia Hemmings", UserName = "amelia.hemmings@fictitious.mil"},
                new ApplicationUser { Email = "joan.white@fictitious.mil", FullName = "Joan White", UserName = "joan.white@fictitious.mil"},
                new ApplicationUser { Email = "alan.walker@fictitious.mil", FullName = "Alan Walker", UserName = "alan.walker@fictitious.mil"},
                new ApplicationUser { Email = "warren.mcgrath@fictitious.mil", FullName = "Warren McGrath", UserName = "warren.mcgrath@fictitious.mil"},
                new ApplicationUser { Email = "fiona.dowd@fictitious.mil", FullName = "Fiona Dowd", UserName = "fiona.dowd@fictitious.mil"},
                new ApplicationUser { Email = "anna.bower@fictitious.mil", FullName = "Anna Bower", UserName = "anna.bower@fictitious.mil"},
                new ApplicationUser { Email = "benjamin.parr@fictitious.mil", FullName = "Benjamin Parr", UserName = "benjamin.parr@fictitious.mil"},
                new ApplicationUser { Email = "mary.may@fictitious.mil", FullName = "Mary May", UserName = "mary.may@fictitious.mil"},
                new ApplicationUser { Email = "karen.johnston@fictitious.mil", FullName = "Karen Johnston", UserName = "karen.johnston@fictitious.mil"},
                new ApplicationUser { Email = "fiona.rees@fictitious.mil", FullName = "Fiona Rees", UserName = "fiona.rees@fictitious.mil"},
                new ApplicationUser { Email = "piers.buckland@fictitious.mil", FullName = "Piers Buckland", UserName = "piers.buckland@fictitious.mil"},
                new ApplicationUser { Email = "dylan.avery@fictitious.mil", FullName = "Dylan Avery", UserName = "dylan.avery@fictitious.mil"},
                new ApplicationUser { Email = "nicholas.duncan@fictitious.mil", FullName = "Nicholas Duncan", UserName = "nicholas.duncan@fictitious.mil"},
                new ApplicationUser { Email = "jonathan.lambert@fictitious.mil", FullName = "Jonathan Lambert", UserName = "jonathan.lambert@fictitious.mil"},
                new ApplicationUser { Email = "anne.powell@fictitious.mil", FullName = "Anne Powell", UserName = "anne.powell@fictitious.mil"},
                new ApplicationUser { Email = "jan.fisher@fictitious.mil", FullName = "Jan Fisher", UserName = "jan.fisher@fictitious.mil"},
                new ApplicationUser { Email = "ryan.newman@fictitious.mil", FullName = "Ryan Newman", UserName = "ryan.newman@fictitious.mil"},
                new ApplicationUser { Email = "sophie.welch@fictitious.mil", FullName = "Sophie Welch", UserName = "sophie.welch@fictitious.mil"},
                new ApplicationUser { Email = "leah.short@fictitious.mil", FullName = "Leah Short", UserName = "leah.short@fictitious.mil"},
                new ApplicationUser { Email = "maria.ince@fictitious.mil", FullName = "Maria Ince", UserName = "maria.ince@fictitious.mil"},
                new ApplicationUser { Email = "colin.coleman@fictitious.mil", FullName = "Colin Coleman", UserName = "colin.coleman@fictitious.mil"},
                new ApplicationUser { Email = "evan.martin@fictitious.mil", FullName = "Evan Martin", UserName = "evan.martin@fictitious.mil"},
                new ApplicationUser { Email = "alexandra.wallace@fictitious.mil", FullName = "Alexandra Wallace", UserName = "alexandra.wallace@fictitious.mil"},
                new ApplicationUser { Email = "maria.watson@fictitious.mil", FullName = "Maria Watson", UserName = "maria.watson@fictitious.mil"},
                new ApplicationUser { Email = "sam.springer@fictitious.mil", FullName = "Sam Springer", UserName = "sam.springer@fictitious.mil"},
                new ApplicationUser { Email = "ava.hemmings@fictitious.mil", FullName = "Ava Hemmings", UserName = "ava.hemmings@fictitious.mil"},
                new ApplicationUser { Email = "richard.kerr@fictitious.mil", FullName = "Richard Kerr", UserName = "richard.kerr@fictitious.mil"},
                new ApplicationUser { Email = "nicholas.ferguson@fictitious.mil", FullName = "Nicholas Ferguson", UserName = "nicholas.ferguson@fictitious.mil"},
                new ApplicationUser { Email = "jan.james@fictitious.mil", FullName = "Jan James", UserName = "jan.james@fictitious.mil"},
                new ApplicationUser { Email = "richard.brown@fictitious.mil", FullName = "Richard Brown", UserName = "richard.brown@fictitious.mil"},
                new ApplicationUser { Email = "edward.harris@fictitious.mil", FullName = "Edward Harris", UserName = "edward.harris@fictitious.mil"},
                new ApplicationUser { Email = "connor.cornish@fictitious.mil", FullName = "Connor Cornish", UserName = "connor.cornish@fictitious.mil"},
                new ApplicationUser { Email = "ava.randall@fictitious.mil", FullName = "Ava Randall", UserName = "ava.randall@fictitious.mil"},
                new ApplicationUser { Email = "fiona.anderson@fictitious.mil", FullName = "Fiona Anderson", UserName = "fiona.anderson@fictitious.mil"},
                new ApplicationUser { Email = "james.lambert@fictitious.mil", FullName = "James Lambert", UserName = "james.lambert@fictitious.mil"},
                new ApplicationUser { Email = "lisa.hudson@fictitious.mil", FullName = "Lisa Hudson", UserName = "lisa.hudson@fictitious.mil"},
                new ApplicationUser { Email = "emily.randall@fictitious.mil", FullName = "Emily Randall", UserName = "emily.randall@fictitious.mil"},
                new ApplicationUser { Email = "stephen.wilson@fictitious.mil", FullName = "Stephen Wilson", UserName = "stephen.wilson@fictitious.mil"},
                new ApplicationUser { Email = "richard.robertson@fictitious.mil", FullName = "Richard Robertson", UserName = "richard.robertson@fictitious.mil"},
                new ApplicationUser { Email = "emma.ince@fictitious.mil", FullName = "Emma Ince", UserName = "emma.ince@fictitious.mil"},
                new ApplicationUser { Email = "joan.duncan@fictitious.mil", FullName = "Joan Duncan", UserName = "joan.duncan@fictitious.mil"},
                new ApplicationUser { Email = "chloe.vaughan@fictitious.mil", FullName = "Chloe Vaughan", UserName = "chloe.vaughan@fictitious.mil"},
                new ApplicationUser { Email = "leah.avery@fictitious.mil", FullName = "Leah Avery", UserName = "leah.avery@fictitious.mil"},
                new ApplicationUser { Email = "evan.hamilton@fictitious.mil", FullName = "Evan Hamilton", UserName = "evan.hamilton@fictitious.mil"},
                new ApplicationUser { Email = "phil.black@fictitious.mil", FullName = "Phil Black", UserName = "phil.black@fictitious.mil"},
                new ApplicationUser { Email = "sebastian.miller@fictitious.mil", FullName = "Sebastian Miller", UserName = "sebastian.miller@fictitious.mil"},
                new ApplicationUser { Email = "caroline.mclean@fictitious.mil", FullName = "Caroline McLean", UserName = "caroline.mclean@fictitious.mil"},
                new ApplicationUser { Email = "mary.macleod@fictitious.mil", FullName = "Mary MacLeod", UserName = "mary.macleod@fictitious.mil"},
                new ApplicationUser { Email = "gavin.vance@fictitious.mil", FullName = "Gavin Vance", UserName = "gavin.vance@fictitious.mil"},
                new ApplicationUser { Email = "grace.hemmings@fictitious.mil", FullName = "Grace Hemmings", UserName = "grace.hemmings@fictitious.mil"},
                new ApplicationUser { Email = "robert.knox@fictitious.mil", FullName = "Robert Knox", UserName = "robert.knox@fictitious.mil"},
                new ApplicationUser { Email = "deirdre.randall@fictitious.mil", FullName = "Deirdre Randall", UserName = "deirdre.randall@fictitious.mil"},
                new ApplicationUser { Email = "diane.pullman@fictitious.mil", FullName = "Diane Pullman", UserName = "diane.pullman@fictitious.mil"},
                new ApplicationUser { Email = "penelope.jones@fictitious.mil", FullName = "Penelope Jones", UserName = "penelope.jones@fictitious.mil"},
                new ApplicationUser { Email = "jack.springer@fictitious.mil", FullName = "Jack Springer", UserName = "jack.springer@fictitious.mil"},
                new ApplicationUser { Email = "anthony.johnston@fictitious.mil", FullName = "Anthony Johnston", UserName = "anthony.johnston@fictitious.mil"},
                new ApplicationUser { Email = "jacob.sharp@fictitious.mil", FullName = "Jacob Sharp", UserName = "jacob.sharp@fictitious.mil"},
                new ApplicationUser { Email = "anna.henderson@fictitious.mil", FullName = "Anna Henderson", UserName = "anna.henderson@fictitious.mil"},
                new ApplicationUser { Email = "stephanie.north@fictitious.mil", FullName = "Stephanie North", UserName = "stephanie.north@fictitious.mil"},
                new ApplicationUser { Email = "kevin.burgess@fictitious.mil", FullName = "Kevin Burgess", UserName = "kevin.burgess@fictitious.mil"},
                new ApplicationUser { Email = "amy.burgess@fictitious.mil", FullName = "Amy Burgess", UserName = "amy.burgess@fictitious.mil"},
                new ApplicationUser { Email = "richard.mcdonald@fictitious.mil", FullName = "Richard McDonald", UserName = "richard.mcdonald@fictitious.mil"},
                new ApplicationUser { Email = "frank.dyer@fictitious.mil", FullName = "Frank Dyer", UserName = "frank.dyer@fictitious.mil"},
                new ApplicationUser { Email = "bella.jones@fictitious.mil", FullName = "Bella Jones", UserName = "bella.jones@fictitious.mil"},
                new ApplicationUser { Email = "austin.murray@fictitious.mil", FullName = "Austin Murray", UserName = "austin.murray@fictitious.mil"},
                new ApplicationUser { Email = "kevin.howard@fictitious.mil", FullName = "Kevin Howard", UserName = "kevin.howard@fictitious.mil"},
                new ApplicationUser { Email = "alison.parsons@fictitious.mil", FullName = "Alison Parsons", UserName = "alison.parsons@fictitious.mil"},
                new ApplicationUser { Email = "alexander.abraham@fictitious.mil", FullName = "Alexander Abraham", UserName = "alexander.abraham@fictitious.mil"},
                new ApplicationUser { Email = "adam.cameron@fictitious.mil", FullName = "Adam Cameron", UserName = "adam.cameron@fictitious.mil"},
                new ApplicationUser { Email = "anna.carr@fictitious.mil", FullName = "Anna Carr", UserName = "anna.carr@fictitious.mil"},
                new ApplicationUser { Email = "samantha.thomson@fictitious.mil", FullName = "Samantha Thomson", UserName = "samantha.thomson@fictitious.mil"},
                new ApplicationUser { Email = "dorothy.wallace@fictitious.mil", FullName = "Dorothy Wallace", UserName = "dorothy.wallace@fictitious.mil"},
                new ApplicationUser { Email = "melanie.sanderson@fictitious.mil", FullName = "Melanie Sanderson", UserName = "melanie.sanderson@fictitious.mil"},
                new ApplicationUser { Email = "dorothy.pullman@fictitious.mil", FullName = "Dorothy Pullman", UserName = "dorothy.pullman@fictitious.mil"},
                new ApplicationUser { Email = "penelope.nash@fictitious.mil", FullName = "Penelope Nash", UserName = "penelope.nash@fictitious.mil"},
                new ApplicationUser { Email = "neil.martin@fictitious.mil", FullName = "Neil Martin", UserName = "neil.martin@fictitious.mil"},
                new ApplicationUser { Email = "tracey.hodges@fictitious.mil", FullName = "Tracey Hodges", UserName = "tracey.hodges@fictitious.mil"},
                new ApplicationUser { Email = "grace.greene@fictitious.mil", FullName = "Grace Greene", UserName = "grace.greene@fictitious.mil"},
                new ApplicationUser { Email = "emma.walsh@fictitious.mil", FullName = "Emma Walsh", UserName = "emma.walsh@fictitious.mil"},
                new ApplicationUser { Email = "julian.alsop@fictitious.mil", FullName = "Julian Alsop", UserName = "julian.alsop@fictitious.mil"},
                new ApplicationUser { Email = "robert.graham@fictitious.mil", FullName = "Robert Graham", UserName = "robert.graham@fictitious.mil"},
                new ApplicationUser { Email = "dorothy.edmunds@fictitious.mil", FullName = "Dorothy Edmunds", UserName = "dorothy.edmunds@fictitious.mil"},
                new ApplicationUser { Email = "sophie.randall@fictitious.mil", FullName = "Sophie Randall", UserName = "sophie.randall@fictitious.mil"},
                new ApplicationUser { Email = "diana.rutherford@fictitious.mil", FullName = "Diana Rutherford", UserName = "diana.rutherford@fictitious.mil"},
                new ApplicationUser { Email = "maria.ogden@fictitious.mil", FullName = "Maria Ogden", UserName = "maria.ogden@fictitious.mil"},
                new ApplicationUser { Email = "owen.glover@fictitious.mil", FullName = "Owen Glover", UserName = "owen.glover@fictitious.mil"},
                new ApplicationUser { Email = "luke.mcgrath@fictitious.mil", FullName = "Luke McGrath", UserName = "luke.mcgrath@fictitious.mil"},
                new ApplicationUser { Email = "irene.mcgrath@fictitious.mil", FullName = "Irene McGrath", UserName = "irene.mcgrath@fictitious.mil"},
                new ApplicationUser { Email = "colin.north@fictitious.mil", FullName = "Colin North", UserName = "colin.north@fictitious.mil"},
                new ApplicationUser { Email = "bernadette.black@fictitious.mil", FullName = "Bernadette Black", UserName = "bernadette.black@fictitious.mil"},
                new ApplicationUser { Email = "justin.brown@fictitious.mil", FullName = "Justin Brown", UserName = "justin.brown@fictitious.mil"},
                new ApplicationUser { Email = "chloe.davies@fictitious.mil", FullName = "Chloe Davies", UserName = "chloe.davies@fictitious.mil"},
                new ApplicationUser { Email = "penelope.peake@fictitious.mil", FullName = "Penelope Peake", UserName = "penelope.peake@fictitious.mil"},
                new ApplicationUser { Email = "faith.blake@fictitious.mil", FullName = "Faith Blake", UserName = "faith.blake@fictitious.mil"},
                new ApplicationUser { Email = "simon.thomson@fictitious.mil", FullName = "Simon Thomson", UserName = "simon.thomson@fictitious.mil"},
                new ApplicationUser { Email = "megan.stewart@fictitious.mil", FullName = "Megan Stewart", UserName = "megan.stewart@fictitious.mil"},
                new ApplicationUser { Email = "madeleine.sanderson@fictitious.mil", FullName = "Madeleine Sanderson", UserName = "madeleine.sanderson@fictitious.mil"},
                new ApplicationUser { Email = "kevin.tucker@fictitious.mil", FullName = "Kevin Tucker", UserName = "kevin.tucker@fictitious.mil"},
                new ApplicationUser { Email = "elizabeth.hodges@fictitious.mil", FullName = "Elizabeth Hodges", UserName = "elizabeth.hodges@fictitious.mil"},
                new ApplicationUser { Email = "lauren.mcgrath@fictitious.mil", FullName = "Lauren McGrath", UserName = "lauren.mcgrath@fictitious.mil"},
                new ApplicationUser { Email = "michelle.cornish@fictitious.mil", FullName = "Michelle Cornish", UserName = "michelle.cornish@fictitious.mil"},
                new ApplicationUser { Email = "cameron.springer@fictitious.mil", FullName = "Cameron Springer", UserName = "cameron.springer@fictitious.mil"},
                new ApplicationUser { Email = "cameron.avery@fictitious.mil", FullName = "Cameron Avery", UserName = "cameron.avery@fictitious.mil"},
                new ApplicationUser { Email = "evan.poole@fictitious.mil", FullName = "Evan Poole", UserName = "evan.poole@fictitious.mil"},
                new ApplicationUser { Email = "leah.black@fictitious.mil", FullName = "Leah Black", UserName = "leah.black@fictitious.mil"},
                new ApplicationUser { Email = "ruth.roberts@fictitious.mil", FullName = "Ruth Roberts", UserName = "ruth.roberts@fictitious.mil"},
                new ApplicationUser { Email = "cameron.abraham@fictitious.mil", FullName = "Cameron Abraham", UserName = "cameron.abraham@fictitious.mil"},
                new ApplicationUser { Email = "dylan.brown@fictitious.mil", FullName = "Dylan Brown", UserName = "dylan.brown@fictitious.mil"},
                new ApplicationUser { Email = "joe.vance@fictitious.mil", FullName = "Joe Vance", UserName = "joe.vance@fictitious.mil"},
                new ApplicationUser { Email = "luke.young@fictitious.mil", FullName = "Luke Young", UserName = "luke.young@fictitious.mil"},
                new ApplicationUser { Email = "abigail.paige@fictitious.mil", FullName = "Abigail Paige", UserName = "abigail.paige@fictitious.mil"},
                new ApplicationUser { Email = "carolyn.arnold@fictitious.mil", FullName = "Carolyn Arnold", UserName = "carolyn.arnold@fictitious.mil"},
                new ApplicationUser { Email = "warren.oliver@fictitious.mil", FullName = "Warren Oliver", UserName = "warren.oliver@fictitious.mil"},
                new ApplicationUser { Email = "diana.powell@fictitious.mil", FullName = "Diana Powell", UserName = "diana.powell@fictitious.mil"},
                new ApplicationUser { Email = "joseph.powell@fictitious.mil", FullName = "Joseph Powell", UserName = "joseph.powell@fictitious.mil"},
                new ApplicationUser { Email = "stephen.robertson@fictitious.mil", FullName = "Stephen Robertson", UserName = "stephen.robertson@fictitious.mil"},
                new ApplicationUser { Email = "dorothy.hudson@fictitious.mil", FullName = "Dorothy Hudson", UserName = "dorothy.hudson@fictitious.mil"},
                new ApplicationUser { Email = "alexander.may@fictitious.mil", FullName = "Alexander May", UserName = "alexander.may@fictitious.mil"},
                new ApplicationUser { Email = "victoria.kerr@fictitious.mil", FullName = "Victoria Kerr", UserName = "victoria.kerr@fictitious.mil"},
                new ApplicationUser { Email = "felicity.fraser@fictitious.mil", FullName = "Felicity Fraser", UserName = "felicity.fraser@fictitious.mil"},
                new ApplicationUser { Email = "kylie.chapman@fictitious.mil", FullName = "Kylie Chapman", UserName = "kylie.chapman@fictitious.mil"},
                new ApplicationUser { Email = "tim.ferguson@fictitious.mil", FullName = "Tim Ferguson", UserName = "tim.ferguson@fictitious.mil"},
                new ApplicationUser { Email = "isaac.bailey@fictitious.mil", FullName = "Isaac Bailey", UserName = "isaac.bailey@fictitious.mil"},
                new ApplicationUser { Email = "sebastian.wallace@fictitious.mil", FullName = "Sebastian Wallace", UserName = "sebastian.wallace@fictitious.mil"},
                new ApplicationUser { Email = "paul.churchill@fictitious.mil", FullName = "Paul Churchill", UserName = "paul.churchill@fictitious.mil"},
                new ApplicationUser { Email = "anna.rutherford@fictitious.mil", FullName = "Anna Rutherford", UserName = "anna.rutherford@fictitious.mil"},
                new ApplicationUser { Email = "sue.martin@fictitious.mil", FullName = "Sue Martin", UserName = "sue.martin@fictitious.mil"},
                new ApplicationUser { Email = "lisa.young@fictitious.mil", FullName = "Lisa Young", UserName = "lisa.young@fictitious.mil"},
                new ApplicationUser { Email = "fiona.arnold@fictitious.mil", FullName = "Fiona Arnold", UserName = "fiona.arnold@fictitious.mil"},
                new ApplicationUser { Email = "anne.randall@fictitious.mil", FullName = "Anne Randall", UserName = "anne.randall@fictitious.mil"},
                new ApplicationUser { Email = "amy.paterson@fictitious.mil", FullName = "Amy Paterson", UserName = "amy.paterson@fictitious.mil"},
                new ApplicationUser { Email = "david.rampling@fictitious.mil", FullName = "David Rampling", UserName = "david.rampling@fictitious.mil"},
                new ApplicationUser { Email = "michael.lyman@fictitious.mil", FullName = "Michael Lyman", UserName = "michael.lyman@fictitious.mil"},
                new ApplicationUser { Email = "fiona.peters@fictitious.mil", FullName = "Fiona Peters", UserName = "fiona.peters@fictitious.mil"},
                new ApplicationUser { Email = "pippa.coleman@fictitious.mil", FullName = "Pippa Coleman", UserName = "pippa.coleman@fictitious.mil"},
                new ApplicationUser { Email = "anthony.henderson@fictitious.mil", FullName = "Anthony Henderson", UserName = "anthony.henderson@fictitious.mil"},
                new ApplicationUser { Email = "connor.coleman@fictitious.mil", FullName = "Connor Coleman", UserName = "connor.coleman@fictitious.mil"},
                new ApplicationUser { Email = "lillian.chapman@fictitious.mil", FullName = "Lillian Chapman", UserName = "lillian.chapman@fictitious.mil"},
                new ApplicationUser { Email = "jack.cornish@fictitious.mil", FullName = "Jack Cornish", UserName = "jack.cornish@fictitious.mil"},
                new ApplicationUser { Email = "benjamin.parsons@fictitious.mil", FullName = "Benjamin Parsons", UserName = "benjamin.parsons@fictitious.mil"},
                new ApplicationUser { Email = "jacob.roberts@fictitious.mil", FullName = "Jacob Roberts", UserName = "jacob.roberts@fictitious.mil"},
                new ApplicationUser { Email = "piers.lambert@fictitious.mil", FullName = "Piers Lambert", UserName = "piers.lambert@fictitious.mil"},
                new ApplicationUser { Email = "una.ball@fictitious.mil", FullName = "Una Ball", UserName = "una.ball@fictitious.mil"},
                new ApplicationUser { Email = "liam.martin@fictitious.mil", FullName = "Liam Martin", UserName = "liam.martin@fictitious.mil"},
                new ApplicationUser { Email = "jacob.hill@fictitious.mil", FullName = "Jacob Hill", UserName = "jacob.hill@fictitious.mil"},
                new ApplicationUser { Email = "faith.fraser@fictitious.mil", FullName = "Faith Fraser", UserName = "faith.fraser@fictitious.mil"},
                new ApplicationUser { Email = "lucas.hamilton@fictitious.mil", FullName = "Lucas Hamilton", UserName = "lucas.hamilton@fictitious.mil"},
                new ApplicationUser { Email = "thomas.baker@fictitious.mil", FullName = "Thomas Baker", UserName = "thomas.baker@fictitious.mil"},
                new ApplicationUser { Email = "jack.alsop@fictitious.mil", FullName = "Jack Alsop", UserName = "jack.alsop@fictitious.mil"},
                new ApplicationUser { Email = "david.walker@fictitious.mil", FullName = "David Walker", UserName = "david.walker@fictitious.mil"},
                new ApplicationUser { Email = "max.turner@fictitious.mil", FullName = "Max Turner", UserName = "max.turner@fictitious.mil"},
                new ApplicationUser { Email = "frank.henderson@fictitious.mil", FullName = "Frank Henderson", UserName = "frank.henderson@fictitious.mil"},
                new ApplicationUser { Email = "virginia.poole@fictitious.mil", FullName = "Virginia Poole", UserName = "virginia.poole@fictitious.mil"},
                new ApplicationUser { Email = "wendy.jackson@fictitious.mil", FullName = "Wendy Jackson", UserName = "wendy.jackson@fictitious.mil"},
                new ApplicationUser { Email = "joseph.nolan@fictitious.mil", FullName = "Joseph Nolan", UserName = "joseph.nolan@fictitious.mil"},
                new ApplicationUser { Email = "gavin.mackay@fictitious.mil", FullName = "Gavin Mackay", UserName = "gavin.mackay@fictitious.mil"},
                new ApplicationUser { Email = "max.hunter@fictitious.mil", FullName = "Max Hunter", UserName = "max.hunter@fictitious.mil"},
                new ApplicationUser { Email = "adrian.duncan@fictitious.mil", FullName = "Adrian Duncan", UserName = "adrian.duncan@fictitious.mil"},
                new ApplicationUser { Email = "rebecca.wilkins@fictitious.mil", FullName = "Rebecca Wilkins", UserName = "rebecca.wilkins@fictitious.mil"},
                new ApplicationUser { Email = "carol.paige@fictitious.mil", FullName = "Carol Paige", UserName = "carol.paige@fictitious.mil"},
                new ApplicationUser { Email = "bernadette.greene@fictitious.mil", FullName = "Bernadette Greene", UserName = "bernadette.greene@fictitious.mil"},
                new ApplicationUser { Email = "diane.scott@fictitious.mil", FullName = "Diane Scott", UserName = "diane.scott@fictitious.mil"},
                new ApplicationUser { Email = "caroline.white@fictitious.mil", FullName = "Caroline White", UserName = "caroline.white@fictitious.mil"},
                new ApplicationUser { Email = "jane.mackenzie@fictitious.mil", FullName = "Jane Mackenzie", UserName = "jane.mackenzie@fictitious.mil"},
                new ApplicationUser { Email = "connor.peake@fictitious.mil", FullName = "Connor Peake", UserName = "connor.peake@fictitious.mil"},
                new ApplicationUser { Email = "christian.bower@fictitious.mil", FullName = "Christian Bower", UserName = "christian.bower@fictitious.mil"},
                new ApplicationUser { Email = "trevor.marshall@fictitious.mil", FullName = "Trevor Marshall", UserName = "trevor.marshall@fictitious.mil"},
                new ApplicationUser { Email = "diane.underwood@fictitious.mil", FullName = "Diane Underwood", UserName = "diane.underwood@fictitious.mil"},
                new ApplicationUser { Email = "dan.metcalfe@fictitious.mil", FullName = "Dan Metcalfe", UserName = "dan.metcalfe@fictitious.mil"},
                new ApplicationUser { Email = "leonard.davidson@fictitious.mil", FullName = "Leonard Davidson", UserName = "leonard.davidson@fictitious.mil"},
                new ApplicationUser { Email = "felicity.terry@fictitious.mil", FullName = "Felicity Terry", UserName = "felicity.terry@fictitious.mil"},
                new ApplicationUser { Email = "edward.stewart@fictitious.mil", FullName = "Edward Stewart", UserName = "edward.stewart@fictitious.mil"},
                new ApplicationUser { Email = "ryan.terry@fictitious.mil", FullName = "Ryan Terry", UserName = "ryan.terry@fictitious.mil"},
                new ApplicationUser { Email = "faith.may@fictitious.mil", FullName = "Faith May", UserName = "faith.may@fictitious.mil"},
                new ApplicationUser { Email = "grace.hart@fictitious.mil", FullName = "Grace Hart", UserName = "grace.hart@fictitious.mil"},
                new ApplicationUser { Email = "joanne.nolan@fictitious.mil", FullName = "Joanne Nolan", UserName = "joanne.nolan@fictitious.mil"},
                new ApplicationUser { Email = "pippa.skinner@fictitious.mil", FullName = "Pippa Skinner", UserName = "pippa.skinner@fictitious.mil"},
                new ApplicationUser { Email = "jonathan.davidson@fictitious.mil", FullName = "Jonathan Davidson", UserName = "jonathan.davidson@fictitious.mil"},
                new ApplicationUser { Email = "wendy.ellison@fictitious.mil", FullName = "Wendy Ellison", UserName = "wendy.ellison@fictitious.mil"},
                new ApplicationUser { Email = "lauren.dickens@fictitious.mil", FullName = "Lauren Dickens", UserName = "lauren.dickens@fictitious.mil"},
                new ApplicationUser { Email = "cameron.martin@fictitious.mil", FullName = "Cameron Martin", UserName = "cameron.martin@fictitious.mil"},
                new ApplicationUser { Email = "sam.glover@fictitious.mil", FullName = "Sam Glover", UserName = "sam.glover@fictitious.mil"},
                new ApplicationUser { Email = "carol.davies@fictitious.mil", FullName = "Carol Davies", UserName = "carol.davies@fictitious.mil"},
                new ApplicationUser { Email = "audrey.vaughan@fictitious.mil", FullName = "Audrey Vaughan", UserName = "audrey.vaughan@fictitious.mil"},
                new ApplicationUser { Email = "yvonne.sharp@fictitious.mil", FullName = "Yvonne Sharp", UserName = "yvonne.sharp@fictitious.mil"},
                new ApplicationUser { Email = "chloe.vance@fictitious.mil", FullName = "Chloe Vance", UserName = "chloe.vance@fictitious.mil"},
                new ApplicationUser { Email = "owen.nash@fictitious.mil", FullName = "Owen Nash", UserName = "owen.nash@fictitious.mil"},
                new ApplicationUser { Email = "sean.lawrence@fictitious.mil", FullName = "Sean Lawrence", UserName = "sean.lawrence@fictitious.mil"},
                new ApplicationUser { Email = "keith.hudson@fictitious.mil", FullName = "Keith Hudson", UserName = "keith.hudson@fictitious.mil"}

            };

            foreach (var user in newUsers)
            {
                user.EmailConfirmed = true;
                var result = await _userManager.CreateAsync(user, "T3mpp@ss!");
            }
        }


        private async Task<object> GenerateJwtToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return  new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
