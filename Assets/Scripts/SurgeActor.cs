using System;
using Newtonsoft.Json;


[System.Serializable]
public abstract class SurgeActor
{
    ///<summary> Altitude of this actor </summary>
    public double _Alt;
    ///<summary> Direction this actor is currently facing/heading </summary>
    public float _Dir;
    ///<summary> The database key of this data </summary>
    public string _ID;
    ///<summary> Has this actor received recent data updates? </summary>
    public bool _isActive;
    ///<summary> Latitude coordinates of this actor </summary>
    public double _Lat;
    ///<summary> Longitiude coordinates of this actor </summary>
    public double _Lon;
    ///<summary> A string containing the most recent timestamp from the server when an update was received for this actor. A comparison will be made to determine if the _isActive state should be changed
    /// based on the current system time and this value. If too much time has passed since the last update, this actor will be set to in-active. Eventually,
    /// the target will be removed completely if too much time has passed since it was updated.
    /// </summary>
    public string _Time;
}


[System.Serializable]
public enum TargetType { DRONE, PERSON, VEHICLE, OBJECTIVE, ANDROID };

[System.Serializable]
public class TargetActor : SurgeActor
{
    ///<summary>If this target is grouped together, how many individual detections does it consist of? </summary>
    public int _Detections;
    ///<summary> The active drone that has detected and is actively tracking this target </summary>
    public string _Drone;
    ///<summary>Is this target grouped together with several co-located detections? </summary>
    public bool _isGroup;
    ///<summary> Distinguishes whether the UI will display: DRONE, PERSON, VEHICLE, ANDROID </summary>
    public int _Type;

    [JsonConstructor]
    public TargetActor() { }

    public TargetActor(TargetActor targetActor)
    {
        this._Alt = targetActor._Alt;
        this._Detections = targetActor._Detections;
        this._Dir = targetActor._Dir;
        this._Drone = targetActor._Drone;
        this._ID = targetActor._ID;
        this._isActive = targetActor._isActive;
        this._isGroup = targetActor._isGroup;
        this._Lat = targetActor._Lat;
        this._Lon = targetActor._Lon;
        this._Time = targetActor._Time;
        this._Type = (int)targetActor._Type;
    }

    public TargetActor(TargetType type, double lat, double lng)
    {
        this._Alt = 0;
        this._Detections = 0;
        this._Dir = 0;
        this._Drone = "na";
        this._ID = "+ New Target";
        this._isActive = true;
        this._isGroup = false;
        this._Lat = lat;
        this._Lon = lng;
        this._Type = (int)type;// which index is the mesh we chose? 1 = person, 2 = vehicle, 3 = objective
        this._Time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds().ToString();

    }

}