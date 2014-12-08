PuppyPaws
=========
A universal Windows Store app written to demonstrate the concepts of service abstraction and separation of concern in a Windows app.
The application consumes the Instagram API to show images of puppies.

####ViewModels and Services
See [PuppyPaws.ClientCommon](PuppyPaws.ClientCommon) for examples of view models consuming services provided by a factory.

####Service Abstraction and Testing
See [PuppyPaws.InstagramApi.PhoneTests](PuppyPaws.InstagramApi.PhoneTests) for examples of testing service implementations. 

####ViewModel Testing
See [PuppyPaws.ClientCommon.PhoneTests](PuppyPaws.ClientCommon.PhoneTests) for examples of mocking service implementations to verify view model functionality.
