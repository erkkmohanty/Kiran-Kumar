using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using Angular_in_19_Days.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;

namespace Angular_in_19_Days.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventRepository _eventRepository;

        public EventsController()
        {

            _eventRepository = new EventRepository();
        }

        public EventsController(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Events
        public ActionResult GetTalkDetails()
        {

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(_eventRepository.GetTasks(), settings),
                ContentType = "application/json"
            };
            return jsonResult;
        }

        public ActionResult GetSpeakerDetails()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new
                    CamelCasePropertyNamesContractResolver()
            };
            var jsonResult = new ContentResult
            {
                Content =
                    JsonConvert.SerializeObject(_eventRepository.GetSpeakers(), settings),
                ContentType = "application/json"
            };
            return jsonResult;
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult AddTalk(TalkVm talkObj,int dat)
        {
            _eventRepository.AddTalk(talkObj);
            return new HttpStatusCodeResult(HttpStatusCode.OK, "Item added");
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult AddTalk2([FromBody]TalkVm talkObj, int dat)
        {
            _eventRepository.AddTalk(talkObj);
            return new HttpStatusCodeResult(HttpStatusCode.OK, "Item added");
        }

        [System.Web.Http.HttpPost]
        public ActionResult AddTalk3(HttpRequestMessage req,[FromBody]TalkVm talkObj, int dat)
        {
            _eventRepository.AddTalk(talkObj);
            return new HttpStatusCodeResult(HttpStatusCode.OK, "Item added");
        }
    }
}