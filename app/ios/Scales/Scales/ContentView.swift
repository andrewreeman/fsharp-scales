import SwiftUI

struct ContentView: View {
    @State private var plistData: ScalesPListData?
    @State private var scale = "Loading scale...";
    
    var body: some View {
        VStack(spacing: 20)
        {
            Spacer()
            Text(scale).font(.custom("Palatino", fixedSize: 24.0))
            Button("New")
            {
                fetchData()
            }
            Spacer()
        }
        .padding(20)
        .frame(
            minWidth: 0,
            maxWidth: .infinity,
            minHeight: 0,
            maxHeight: .infinity,
            alignment: .topLeading
        )
        .onAppear {
            onAppear()
        }
    }
    
    private func onAppear()
    {
        plistData = getPListData()
        fetchData()
    }
    
    private func fetchData() {
        guard let apiUrl = URL.init(string: plistData!.apiUrl) else { return }
        let url = apiUrl.appending(path: "scale/exercise")
        
        URLSession.shared.dataTask(with: url) { data, response, error in
            if let unwrappedError = error {
                DispatchQueue.main.async {
                    scale = unwrappedError.localizedDescription
                }
                return
            }
            
            guard let data = data else { return }
            let scaleString = String.init(data: data, encoding: .utf8)
            DispatchQueue.main.async {
                scale = scaleString ?? "Error loading scale"
            }
        }.resume()
    }
    
    private func getPListData() -> ScalesPListData? {
        guard
            let plistUrl = Bundle.main.url(forResource: "Scales", withExtension: "plist"),
            let plistData = try? Data.init(contentsOf: plistUrl)
        else { return nil }
        
        do
        {
            return try PropertyListDecoder().decode(ScalesPListData.self, from: plistData)
        } catch {
            print(error)
            return nil
        }
    }

}

#Preview {
    ContentView()
}

private struct ScalesPListData: Codable
{
    let apiUrl: String
}
