using BackendAPI.Interfaces.Repository;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendAPI.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase {

		private readonly IUserRepository _userRepository;
		public UserController(IUserRepository userRepository) {
			_userRepository = userRepository;
		}
		
		[HttpGet]
		public async Task<ActionResult<List<UserModel>>> GetAllUsers() {

			List<UserModel> users = await _userRepository.SelectAll();
			return Ok(users);
		}
		
		[HttpGet("{id}")]
		public async Task<ActionResult<UserModel>> GetById(int id) {

			UserModel user = await _userRepository.GetById(id);
			return Ok(User);
		}

		//// POST api/<UserController>
		//[HttpPost]
		//public void Post([FromBody] string value) {
		//}

		//// PUT api/<UserController>/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value) {
		//}

		//// DELETE api/<UserController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id) {
		//}
	}
}
